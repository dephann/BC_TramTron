using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace NDPSo.Chatbot
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        // Alias chuẩn đã khai báo trong JOIN_PATTERNS
        private static readonly Dictionary<string, string> ALIAS_MAP = new Dictionary<string, string>
        {
            { "MeTron",                  "mt"  },
            { "MeTronChiTiet",           "mct" },
            { "MeTronChiTietGiaoHang",   "mctg"},
            { "PhieuTron",               "pt"  },
            { "PhieuGiaoHang",           "pg"  },
            { "KhachHang",               "kh"  },
            { "CongTruong",              "ct"  },
            { "HopDong",                 "hd"  },
            { "HangMuc",                 "hm"  },
            { "MAC",                     "m"   },
            { "MACSilo",                 "ms"  },
            { "Silo",                    "s"   },
            { "NhomSilo",                "ns"  },
            { "Material",                "mat" },
            { "TaiXe",                   "tx"  },
            { "Xe",                      "xe"  },
            { "NhanVien",                "nv"  },
            { "SEC_User",                "u"   },
            { "EventLog",                "el"  },
            { "EventActionCode",         "ea"  },
            { "TinhDoHutNuoc",           "t"   },
            { "TinhDoHutNuocChiTiet",    "tc"  },
            { "DuLieuTron",              "dlt" },
        };

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool TestConnection()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch { return false; }
        }

        public string ExecuteQuery(string sql)
        {
            sql = SanitizeSql(sql);

            var paramError = CheckUnresolvedParams(sql);
            if (paramError != null)
                throw new Exception(paramError);

            if (!IsSafeQuery(sql))
                throw new Exception("Chỉ cho phép câu truy vấn SELECT.");

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 30;
                    using (var reader = cmd.ExecuteReader())
                        return FormatResult(reader);
                }
            }
        }

        // ══════════════════════════════════════════════════════
        //  SANITIZE — làm sạch và tự sửa SQL do AI sinh
        // ══════════════════════════════════════════════════════
        private string SanitizeSql(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql)) return sql;

            // 1. Xóa backtick (MySQL syntax)
            sql = sql.Replace("`", "");

            // 2. Xóa dấu chấm phẩy cuối
            sql = sql.TrimEnd(';', ' ', '\n', '\r');

            // 3. Xóa prefix "sql" nếu model để lại
            sql = Regex.Replace(sql, @"^sql\s+", "", RegexOptions.IgnoreCase).Trim();

            // 4. Xóa comment -- (đôi khi model thêm vào)
            sql = Regex.Replace(sql, @"--[^\n]*", " ").Trim();

            // 5. Tự động fix alias conflict
            sql = FixAliasConflict(sql);

            return sql;
        }

        /// <summary>
        /// Fix 2 loại lỗi alias phổ biến do AI sinh ra:
        ///
        /// Lỗi 1 — Dùng tên bảng đầy đủ sau khi đã đặt alias:
        ///   SELECT MeTronChiTiet.ValueBat FROM dbo.MeTronChiTiet mct
        ///   → SELECT mct.ValueBat FROM dbo.MeTronChiTiet mct
        ///
        /// Lỗi 2 — Hoán đổi alias sai convention:
        ///   FROM dbo.MeTronChiTiet mt JOIN dbo.MeTron m  (mt↔mct bị hoán đổi)
        ///   → FROM dbo.MeTronChiTiet mct JOIN dbo.MeTron mt
        /// </summary>
        private string FixAliasConflict(string sql)
        {
            // ── Bước 1: Parse tất cả alias được khai báo ─────
            var declaredAliases = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            var aliasDeclarations = Regex.Matches(sql,
                @"(?:dbo\.)?(\w+)\s+(?:AS\s+)?([a-zA-Z_][a-zA-Z0-9_]{0,4})\b",
                RegexOptions.IgnoreCase);

            foreach (Match m in aliasDeclarations)
            {
                string tableName = m.Groups[1].Value;
                string alias = m.Groups[2].Value;
                if (ALIAS_MAP.ContainsKey(tableName) && !IsSqlKeyword(alias))
                    declaredAliases[tableName] = alias;
            }

            if (declaredAliases.Count == 0) return sql;

            // ── Bước 2: Kiểm tra và sửa alias bị hoán đổi ───
            // Ví dụ: MeTronChiTiet dùng alias "mt" thay vì "mct"
            //        MeTron dùng alias "m" thay vì "mt"
            // Chiến lược: nếu alias AI dùng TRÙNG với alias chuẩn của bảng KHÁC
            //             → đổi về alias chuẩn của bảng hiện tại
            bool needsAliasRename = false;
            var renames = new Dictionary<string, string>(); // oldAlias → newAlias

            foreach (var kvp in declaredAliases)
            {
                string tableName = kvp.Key;
                string usedAlias = kvp.Value;
                string correctAlias = ALIAS_MAP[tableName];

                if (!string.Equals(usedAlias, correctAlias, StringComparison.OrdinalIgnoreCase))
                {
                    renames[usedAlias] = correctAlias;
                    needsAliasRename = true;
                }
            }

            if (needsAliasRename)
            {
                // Đổi tên alias trong toàn bộ SQL
                // Phải đổi theo thứ tự dài trước (tránh partial match)
                foreach (var rename in renames)
                {
                    string oldAlias = rename.Key;
                    string newAlias = rename.Value;

                    // Chỉ đổi khi là word boundary để không match substring
                    sql = Regex.Replace(sql,
                        $@"\b{Regex.Escape(oldAlias)}\b",
                        newAlias,
                        RegexOptions.IgnoreCase);
                }

                // Re-parse sau khi rename
                declaredAliases.Clear();
                aliasDeclarations = Regex.Matches(sql,
                    @"(?:dbo\.)?(\w+)\s+(?:AS\s+)?([a-zA-Z_][a-zA-Z0-9_]{0,4})\b",
                    RegexOptions.IgnoreCase);
                foreach (Match m in aliasDeclarations)
                {
                    string tableName = m.Groups[1].Value;
                    string alias = m.Groups[2].Value;
                    if (ALIAS_MAP.ContainsKey(tableName) && !IsSqlKeyword(alias))
                        declaredAliases[tableName] = alias;
                }
            }

            // ── Bước 3: Thay TênBảng.Cột → alias.Cột ────────
            foreach (var kvp in declaredAliases)
            {
                string tableName = kvp.Key;
                string alias = kvp.Value;

                sql = Regex.Replace(sql,
                    $@"(?<![\w\.]){Regex.Escape(tableName)}\.(\w+)",
                    $"{alias}.$1");
            }

            return sql;
        }

        private bool IsSqlKeyword(string word)
        {
            var keywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "SELECT","FROM","WHERE","JOIN","ON","AND","OR","NOT","IN","IS",
                "NULL","TOP","ORDER","BY","GROUP","HAVING","INNER","LEFT","RIGHT",
                "OUTER","AS","WITH","CAST","CASE","WHEN","THEN","ELSE","END",
                "COUNT","SUM","AVG","MIN","MAX","DISTINCT","ALL","INTO","VALUES",
                "SET","UPDATE","DELETE","INSERT","CREATE","ALTER","DROP","TABLE",
                "VIEW","INDEX","CONSTRAINT","PRIMARY","KEY","FOREIGN","REFERENCES",
                "MONTH","YEAR","DAY","DATEPART","GETDATE","DATEADD","DATEDIFF"
            };
            return keywords.Contains(word);
        }

        // ══════════════════════════════════════════════════════
        //  VALIDATION
        // ══════════════════════════════════════════════════════
        private string CheckUnresolvedParams(string sql)
        {
            var matches = Regex.Matches(sql, @"@\w+");
            if (matches.Count == 0) return null;

            var paramList = new List<string>();
            foreach (Match m in matches)
                if (!paramList.Contains(m.Value))
                    paramList.Add(m.Value);

            return $"SQL_PARAM_ERROR: SQL chứa tham số chưa gán giá trị: {string.Join(", ", paramList)}. " +
                   $"Hãy sinh lại SQL với giá trị cụ thể thay vì tham số.";
        }

        private bool IsSafeQuery(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql)) return false;
            var upper = sql.Trim().ToUpper();
            if (!upper.StartsWith("SELECT")) return false;
            var forbidden = new[] {
                "INSERT","UPDATE","DELETE","DROP","CREATE",
                "ALTER","TRUNCATE","EXEC","EXECUTE","SP_","XP_"
            };
            foreach (var kw in forbidden)
                if (Regex.IsMatch(upper, $@"\b{kw}\b")) return false;
            return true;
        }

        // ══════════════════════════════════════════════════════
        //  FORMAT RESULT
        // ══════════════════════════════════════════════════════
        private string FormatResult(SqlDataReader reader)
        {
            var sb = new StringBuilder();
            var columns = new List<string>();

            for (int i = 0; i < reader.FieldCount; i++)
                columns.Add(reader.GetName(i));

            int rowCount = 0;
            sb.AppendLine("[");

            while (reader.Read() && rowCount < 200)
            {
                if (rowCount > 0) sb.AppendLine(",");
                sb.Append("  {");
                for (int i = 0; i < columns.Count; i++)
                {
                    var value = reader.IsDBNull(i) ? "null" : reader[i].ToString();
                    value = value.Replace("\"", "'");
                    if (i > 0) sb.Append(", ");
                    sb.Append($"\"{columns[i]}\": \"{value}\"");
                }
                sb.Append("}");
                rowCount++;
            }

            sb.AppendLine("\n]");
            sb.AppendLine($"-- Tổng: {rowCount} dòng");

            return rowCount == 0 ? "Không có dữ liệu" : sb.ToString();
        }
    }
}