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

            // Kiểm tra có tham số @param chưa được thay thế không
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
                    {
                        return FormatResult(reader);
                    }
                }
            }
        }

        /// <summary>
        /// Kiểm tra SQL có chứa tham số @xxx chưa được gán giá trị không.
        /// Nếu có → trả về thông báo lỗi rõ ràng để Orchestrator biết cần retry.
        /// </summary>
        private string CheckUnresolvedParams(string sql)
        {
            // Tìm tất cả @thamso trong SQL
            var matches = Regex.Matches(sql, @"@\w+");
            if (matches.Count == 0) return null;

            var paramList = new List<string>();
            foreach (Match m in matches)
                if (!paramList.Contains(m.Value))
                    paramList.Add(m.Value);

            return $"SQL_PARAM_ERROR: Câu SQL chứa tham số chưa được gán giá trị: {string.Join(", ", paramList)}. " +
                   $"Hãy sinh lại SQL với giá trị cụ thể thay vì dùng tham số.";
        }

        /// <summary>
        /// Làm sạch SQL do AI sinh ra
        /// </summary>
        private string SanitizeSql(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql)) return sql;

            // Xóa backtick (MySQL syntax)
            sql = sql.Replace("`", "");

            // Xóa dấu chấm phẩy cuối
            sql = sql.TrimEnd(';', ' ', '\n', '\r');

            // Xóa prefix "sql" nếu model vô tình để lại
            sql = Regex.Replace(sql, @"^sql\s+", "", RegexOptions.IgnoreCase).Trim();

            // Xóa comment -- ... (đôi khi model thêm comment vào)
            sql = Regex.Replace(sql, @"--[^\n]*", "").Trim();

            return sql;
        }

        private bool IsSafeQuery(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql)) return false;

            var upper = sql.Trim().ToUpper();
            if (!upper.StartsWith("SELECT")) return false;

            var forbidden = new[] {
                "INSERT", "UPDATE", "DELETE", "DROP", "CREATE",
                "ALTER", "TRUNCATE", "EXEC", "EXECUTE", "SP_", "XP_"
            };
            foreach (var kw in forbidden)
                if (Regex.IsMatch(upper, $@"\b{kw}\b")) return false;

            return true;
        }

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