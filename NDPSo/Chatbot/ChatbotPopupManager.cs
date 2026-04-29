using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading.Tasks;
using DevExpress.XtraBars;

namespace NDPSo.Chatbot
{
    // ═══════════════════════════════════════════════════════════════════
    //  CHATBOT POPUP MANAGER
    //  Quản lý nút float + popup. Gọi từ MainForm 3 dòng là xong.
    // ═══════════════════════════════════════════════════════════════════
    public class ChatbotPopupManager
    {
        private readonly Form _host;
        private readonly ChatbotOrchestrator _ai;
        private FloatBtn _fab;
        private PopupWindow _win;
        private readonly BarButtonItem _plcItem; // để tính vị trí sát bbiConnectPLC

        public ChatbotPopupManager(Form parentForm, string apiKey, string connStr,
                                   BarButtonItem plcItem = null)
        {
            _host = parentForm;
            _plcItem = plcItem;
            _ai = new ChatbotOrchestrator(apiKey, connStr);
            _ai.OnStatusChanged += OnStatus;

            _fab = new FloatBtn();
            _fab.Click += (s, e) => Toggle();
            _host.Controls.Add(_fab);
            _fab.BringToFront();

            _host.Resize += (s, e) => PlaceFab();
            _host.Move += (s, e) => { if (_win != null && _win.Visible) PlaceWin(); };
            // BeginInvoke để đợi BarManager layout xong rồi mới tính vị trí
            _host.Shown += (s, e) => _host.BeginInvoke((Action)PlaceFab);
        }

        private void Toggle()
        {
            if (_win == null || _win.IsDisposed)
            {
                _win = new PopupWindow(_ai);
                _win.FormClosed += (s, e) => { _fab.Active = false; _fab.Invalidate(); };
            }

            if (_win.Visible)
            {
                _win.SlideOut();
                _fab.Active = false;
            }
            else
            {
                PlaceWin();
                _win.SlideIn();
                _fab.Active = true;
            }
            _fab.Invalidate();
        }

        private void PlaceFab()
        {
            // Tìm barDockControlBottom (status bar DevExpress)
            Control statusBar = null;
            foreach (Control c in _host.Controls)
            {
                if (c.Name == "barDockControlBottom") { statusBar = c; break; }
            }

            int fabY = statusBar != null && statusBar.Height > 0
                ? statusBar.Top + (statusBar.Height - _fab.Height) / 2
                : _host.ClientSize.Height - _fab.Height - 4;

            int fabX;

            // Lấy vị trí trái của bbiConnectPLC
            // link.Bounds trong DevExpress là screen coordinates → dùng PointToClient trực tiếp
            if (_plcItem != null && _plcItem.Links.Count > 0)
            {
                try
                {
                    var link  = _plcItem.Links[0];
                    var bounds = link.Bounds;
                    if (bounds.Width > 0)
                    {
                        // Bounds là screen coordinates
                        var clientPt = _host.PointToClient(new Point(bounds.X, bounds.Y));
                        fabX = clientPt.X - _fab.Width;
                    }
                    else
                    {
                        // Bounds chưa sẵn sàng → fallback ước tính
                        fabX = _host.ClientSize.Width - _fab.Width - 125;
                    }
                }
                catch
                {
                    fabX = _host.ClientSize.Width - _fab.Width - 125;
                }
            }
            else
            {
                fabX = _host.ClientSize.Width - _fab.Width - 125;
            }

            _fab.Location = new Point(Math.Max(0, fabX), Math.Max(0, fabY));
            _fab.BringToFront();
        }

        private static Control FindControl(Control parent, string name)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Name == name) return c;
                var found = FindControl(c, name);
                if (found != null) return found;
            }
            return null;
        }

        private void PlaceWin()
        {
            var fabScreen = _host.PointToScreen(_fab.Location);
            var screen = Screen.FromControl(_host).WorkingArea;
            int x = fabScreen.X + _fab.Width - _win.Width;
            int y = fabScreen.Y - _win.Height - 8;
            if (x < screen.Left) x = screen.Left + 8;
            if (y < screen.Top) y = fabScreen.Y + _fab.Height + 8;
            _win.Location = new Point(x, y);
        }

        private void OnStatus(string s)
        {
            if (_win != null && !_win.IsDisposed && _win.InvokeRequired)
                _win.Invoke((Action)(() => _win.SetStatus(s)));
            else if (_win != null && !_win.IsDisposed)
                _win.SetStatus(s);
        }
    }

    // ═══════════════════════════════════════════════════════════════════
    //  FLOATING BUTTON  — nhỏ gọn, nằm trong status bar
    // ═══════════════════════════════════════════════════════════════════
    public class FloatBtn : Panel
    {
        public bool Active { get; set; }
        private bool _hover;

        private const int BTN_W = 72;
        private const int BTN_H = 24;

        public FloatBtn()
        {
            Size = new Size(BTN_W, BTN_H);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            MouseEnter += (s, e) => { _hover = true; Invalidate(); };
            MouseLeave += (s, e) => { _hover = false; Invalidate(); };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            // Nền rounded rectangle phủ toàn bộ control
            var bgColor = _hover
                ? Color.FromArgb(75, 75, 92)
                : Active ? Color.FromArgb(62, 62, 80) : Color.FromArgb(45, 45, 58);

            var rect = new Rectangle(0, 1, BTN_W - 1, BTN_H - 2);
            int r = 4;
            using (var path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
                path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
                path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
                path.CloseFigure();
                using (var b = new SolidBrush(bgColor))
                    g.FillPath(b, path);
                using (var p = new Pen(Color.FromArgb(85, 85, 105), 1f))
                    g.DrawPath(p, path);
            }

            // Icon + label
            string icon = Active ? "✕  Đóng" : "🤖 CMix AI";
            using (var f = new Font("Segoe UI Emoji", 8f, FontStyle.Regular))
            using (var b = new SolidBrush(Color.FromArgb(215, 215, 225)))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                g.DrawString(icon, f, b, new RectangleF(0, 0, BTN_W, BTN_H), sf);

            // Dấu "|" phân cách — lùi vào 4px để tránh vùng rounded corner
            using (var p = new Pen(Color.FromArgb(170, 170, 190), 1.5f))
                g.DrawLine(p, BTN_W - 5, 5, BTN_W - 5, BTN_H - 5);
        }
    }

    // ═══════════════════════════════════════════════════════════════════
    //  POPUP WINDOW
    //  - Dùng TableLayoutPanel 3 rows: Header | Body | Footer
    //  - Body = Panel với custom scroll
    //  - Footer = RichTextBox tự giãn
    // ═══════════════════════════════════════════════════════════════════
    public class PopupWindow : Form
    {
        // ── Palette ───────────────────────────────────────────
        static readonly Color C_WIN = Color.FromArgb(22, 22, 26);
        static readonly Color C_HDR = Color.FromArgb(28, 28, 33);
        static readonly Color C_BODY = Color.FromArgb(18, 18, 22);
        static readonly Color C_FTR = Color.FromArgb(22, 22, 26);
        static readonly Color C_BORD = Color.FromArgb(44, 44, 52);
        static readonly Color C_TXT = Color.FromArgb(210, 210, 218);
        static readonly Color C_MUT = Color.FromArgb(105, 105, 118);
        static readonly Color C_UBG = Color.FromArgb(50, 50, 62);  // user bubble
        static readonly Color C_BBG = Color.FromArgb(12, 12, 16);  // bot bubble
        static readonly Color C_BBRD = Color.FromArgb(18, 18, 22);  // bot border
        static readonly Color C_BTN = Color.FromArgb(55, 55, 70);

        // ── References ───────────────────────────────────────
        private readonly ChatbotOrchestrator _ai;
        private TableLayoutPanel _tbl;
        private Panel _body;        // scrollable message area
        private Panel _msgStack;    // grows downward inside body
        private RichTextBox _rtb;         // input
        private Label _lblHint;
        private Label _lblStatus;
        private Button _btnSend;
        private Panel _footer;

        private int _stackY = 8;
        private bool _busy = false;
        // Lưu lịch sử để copy
        private readonly System.Collections.Generic.List<(bool isUser, string text)> _history
            = new System.Collections.Generic.List<(bool, string)>();

        private const int WIN_W = 420;
        private const int WIN_H = 540;
        private const int HDR_H = 54;
        private const int FTR_H_MIN = 76;
        private const int FTR_H_MAX = 220;

        public PopupWindow(ChatbotOrchestrator ai)
        {
            _ai = ai;

            // Form settings
            FormBorderStyle = FormBorderStyle.None;
            Size = new Size(WIN_W, WIN_H);
            StartPosition = FormStartPosition.Manual;
            BackColor = C_WIN;
            ShowInTaskbar = false;
            TopMost = true;
            DoubleBuffered = true;
            Opacity = 0;

            BuildUI();

            Shown += (s, e) =>
            {
                AppendBot("Chào bạn! Mình là CMix AI, trợ lý vận hành trạm trộn bê tông.\nBạn có thể hỏi mình về sản lượng, phiếu trộn, vật liệu, xe, hợp đồng...");
                _rtb.Focus();
            };
        }

        // ── Build UI ────────────────────────────────────────────
        private void BuildUI()
        {
            // Root: 3-row table  Header | Body | Footer
            _tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1,
                BackColor = C_WIN,
                Padding = new Padding(0),
                Margin = new Padding(0),
            };
            _tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            _tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, HDR_H));
            _tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            _tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, FTR_H_MIN));

            _tbl.Controls.Add(BuildHeader(), 0, 0);
            _tbl.Controls.Add(BuildBody(), 0, 1);
            _tbl.Controls.Add(BuildFooter(), 0, 2);

            Controls.Add(_tbl);
        }

        // ── Header ─────────────────────────────────────────────
        private Panel BuildHeader()
        {
            var hdr = new Panel { Dock = DockStyle.Fill, BackColor = C_HDR };

            // Bottom border
            hdr.Paint += (s, e) =>
            {
                using (var p = new Pen(C_BORD))
                    e.Graphics.DrawLine(p, 0, hdr.Height - 1, hdr.Width, hdr.Height - 1);
            };

            // Avatar với nền tròn sáng
            var iconBg = new Panel
            {
                Size = new Size(34, 34),
                Location = new Point(12, (HDR_H - 34) / 2),
                BackColor = Color.FromArgb(22, 22, 26),
            };
            iconBg.Paint += (s, e) =>
            {
                var g2 = e.Graphics; g2.SmoothingMode = SmoothingMode.AntiAlias;
                using (var b = new SolidBrush(Color.FromArgb(62, 62, 82)))
                    g2.FillEllipse(b, 0, 0, 33, 33);
                using (var p2 = new Pen(Color.FromArgb(85, 85, 105)))
                    g2.DrawEllipse(p2, 0, 0, 33, 33);
            };
            var icon = new Label
            {
                Text = "🤖",
                Font = new Font("Segoe UI Emoji", 14f),
                ForeColor = C_TXT,
                Size = new Size(34, 34),
                Location = new Point(0, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
            };
            iconBg.Controls.Add(icon);

            var title = new Label
            {
                Text = "CMix AI",
                Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold),
                ForeColor = C_TXT,
                Location = new Point(54, 11),
                Size = new Size(260, 18),
                BackColor = Color.Transparent,
            };

            var sub = new Label
            {
                Text = "Trợ lý vận hành trạm trộn",
                Font = new Font("Segoe UI", 8f),
                ForeColor = C_MUT,
                Location = new Point(54, 30),
                Size = new Size(260, 14),
                BackColor = Color.Transparent,
            };

            var btnClose = MakeIconBtn("✕", new Point(WIN_W - 38, (HDR_H - 26) / 2), new Size(26, 26));
            btnClose.Click += (s, e) => SlideOut();

            // Nút New Chat
            var btnNew = MakeIconBtn("✦", new Point(WIN_W - 102, (HDR_H - 26) / 2), new Size(26, 26));
            btnNew.Font = new Font("Segoe UI", 11f);
            btnNew.Click += (s, e) => NewChat();

            // Nút Copy
            var btnCopy = MakeIconBtn("⧉", new Point(WIN_W - 70, (HDR_H - 26) / 2), new Size(26, 26));
            btnCopy.Font = new Font("Segoe UI", 13f);
            btnCopy.Click += (s, e) => CopyHistory();

            // Tooltip
            var tip = new ToolTip { InitialDelay = 400, ReshowDelay = 200 };
            tip.SetToolTip(btnNew, "Cuộc trò chuyện mới");
            tip.SetToolTip(btnCopy, "Sao chép hội thoại");
            tip.SetToolTip(btnClose, "Đóng");

            hdr.Controls.AddRange(new Control[] { iconBg, title, sub, btnNew, btnCopy, btnClose });
            return hdr;
        }

        // ── Body (message area) ────────────────────────────────
        private Control BuildBody()
        {
            _body = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = C_BODY,
                Padding = new Padding(0),
            };

            // msgStack grows inside body — scroll is done by moving its Top
            _msgStack = new Panel
            {
                BackColor = C_BODY,
                Left = 0,
                Top = 0,
                Width = WIN_W,
                Height = 16,
            };

            _body.Controls.Add(_msgStack);

            // Mouse wheel
            _body.MouseWheel += OnWheel;
            _msgStack.MouseWheel += OnWheel;

            _body.Resize += (s, e) =>
            {
                _msgStack.Width = _body.ClientSize.Width;
                ClampScroll();
            };

            return _body;
        }

        private void OnWheel(object s, MouseEventArgs e)
        {
            int delta = e.Delta / 3;
            int newTop = Math.Min(0, Math.Max(_body.ClientSize.Height - _msgStack.Height, _msgStack.Top + delta));
            _msgStack.Top = newTop;
        }

        private void ClampScroll()
        {
            int min = Math.Min(0, _body.ClientSize.Height - _msgStack.Height);
            _msgStack.Top = Math.Max(min, Math.Min(0, _msgStack.Top));
        }

        private void ScrollToBottom()
        {
            int min = _body.ClientSize.Height - _msgStack.Height;
            _msgStack.Top = Math.Min(0, min);
        }

        // ── Footer (input) ─────────────────────────────────────
        private Panel BuildFooter()
        {
            _footer = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = C_FTR,
                Padding = new Padding(8, 6, 8, 6),
            };

            // Top border
            _footer.Paint += (s, e) =>
            {
                using (var p = new Pen(C_BORD))
                    e.Graphics.DrawLine(p, 0, 0, _footer.Width, 0);
            };

            // Inner rounded box
            var box = new Panel
            {
                BackColor = Color.FromArgb(32, 32, 38),
                Dock = DockStyle.Fill,
                Padding = new Padding(14, 8, 10, 8),
            };
            // Không border — giữ nguyên nền tối

            // Dùng PlaceholderRtb — RichTextBox vẽ placeholder trong OnPaint
            // Không dùng Label đè lên vì gây mất text khi gõ
            _rtb = new PlaceholderRtb
            {
                Placeholder = "Do anything with AI...",
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(32, 32, 38),
                ForeColor = C_TXT,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10f),
                ScrollBars = RichTextBoxScrollBars.None,
                WordWrap = true,
            };
            _rtb.TextChanged += RtbChanged;
            _rtb.KeyDown += RtbKeyDown;
            _lblHint = null; // không dùng nữa

            box.Controls.Add(_rtb);

            // Left: "+" attachment button


            // Right: Send button
            _btnSend = new RoundButton
            {
                Text = "➤",
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(35, 35),
                Dock = DockStyle.Right,
                Margin = new Padding(0, 4, 0, 4),
                Cursor = Cursors.Hand,
                TabStop = false,
            };
            _btnSend.Click += (s, e) => Send();

            // Status bar
            _lblStatus = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 8f),
                ForeColor = C_MUT,
                Dock = DockStyle.Bottom,
                Height = 16,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = C_FTR,
            };

            _footer.Controls.Add(box);

            _footer.Controls.Add(_btnSend);
            _footer.Controls.Add(_lblStatus);

            return _footer;
        }

        // ── Input events ────────────────────────────────────────
        private void RtbKeyDown(object s, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                Send();
            }
        }

        private void RtbChanged(object s, EventArgs e)
        {
            // Đo chiều cao cần thiết từ số dòng thực tế
            int lastLine = _rtb.GetLineFromCharIndex(_rtb.TextLength);
            int lineH = _rtb.Font.Height + 2;
            int contentH = (lastLine + 1) * lineH;
            int newH = Math.Max(FTR_H_MIN, Math.Min(FTR_H_MAX, contentH + 36));
            _tbl.RowStyles[2] = new RowStyle(SizeType.Absolute, newH);
        }

        // ── Send / Receive ──────────────────────────────────────
        private async void Send()
        {
            if (_busy) return;
            var txt = _rtb.Text.Trim();
            if (string.IsNullOrEmpty(txt)) return;

            _rtb.Clear();
            _busy = true;
            _btnSend.Enabled = false;
            _tbl.RowStyles[2] = new RowStyle(SizeType.Absolute, FTR_H_MIN); // reset height

            AppendUser(txt);
            var typing = AppendTyping();

            try
            {
                var r = await _ai.ProcessQuestionAsync(txt);
                RemoveBubble(typing);
                AppendBot(r.Answer ?? "Không có phản hồi.");
            }
            catch (Exception ex)
            {
                RemoveBubble(typing);
                AppendBot($"Lỗi: {ex.Message}");
            }
            finally
            {
                _busy = false;
                _btnSend.Enabled = true;
                _lblStatus.Text = "";
                _rtb.Focus();
            }
        }

        public void SetStatus(string s) => _lblStatus.Text = s;

        private void NewChat()
        {
            // Xóa tất cả bubble
            _msgStack.Controls.Clear();
            _stackY = 8;
            _msgStack.Height = 16;
            _history.Clear();
            _msgStack.Top = 0;

            // Greeting mới
            AppendBot("Cuộc trò chuyện mới bắt đầu! Mình có thể giúp gì cho bạn?");
            _rtb.Focus();
        }

        private void CopyHistory()
        {
            if (_history.Count == 0)
            {
                MessageBox.Show("Chưa có nội dung hội thoại.", "CMix AI",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sb = new System.Text.StringBuilder();
            sb.AppendLine("=== Hội thoại CMix AI ===");
            sb.AppendLine($"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm}");
            sb.AppendLine(new string('─', 40));
            sb.AppendLine();

            foreach (var (isUser, text) in _history)
            {
                if (isUser)
                {
                    sb.AppendLine("👤 Bạn:");
                    sb.AppendLine($"   {text}");
                }
                else
                {
                    sb.AppendLine("🤖 CMix AI:");
                    // indent mỗi dòng
                    foreach (var line in text.Split('\n'))
                        sb.AppendLine($"   {line}");
                }
                sb.AppendLine();
            }

            try
            {
                Clipboard.SetText(sb.ToString());
                SetStatus("✅ Đã copy hội thoại vào clipboard!");
                // Xóa status sau 3 giây
                var t = new System.Windows.Forms.Timer { Interval = 3000 };
                t.Tick += (s, e) => { SetStatus(""); t.Stop(); t.Dispose(); };
                t.Start();
            }
            catch
            {
                MessageBox.Show("Không thể copy. Vui lòng thử lại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ── Bubble factory ──────────────────────────────────────
        private void AppendUser(string text)
        {
            _history.Add((true, text));
            AddBubble(text, true, false);
        }
        private void AppendBot(string text)
        {
            _history.Add((false, text));
            AddBubble(text, false, false);
        }

        private BubblePanel AppendTyping()
        {
            var b = new BubblePanel("", false, true, _msgStack.Width);
            Place(b);
            return b;
        }

        private void RemoveBubble(BubblePanel b)
        {
            if (b == null) return;
            _stackY -= b.Height + 6;
            _msgStack.Controls.Remove(b);
            _msgStack.Height = Math.Max(16, _stackY);
            b.Dispose();
        }

        private void AddBubble(string text, bool user, bool typing)
        {
            if (_msgStack.InvokeRequired)
            { _msgStack.Invoke((Action)(() => AddBubble(text, user, typing))); return; }
            Place(new BubblePanel(text, user, typing, _msgStack.Width));
        }

        private void Place(BubblePanel b)
        {
            b.Top = _stackY;
            b.Left = 0;
            b.Width = _msgStack.Width;
            _msgStack.Controls.Add(b);
            _stackY += b.Height + 6;
            _msgStack.Height = _stackY + 8;
            ScrollToBottom();
        }

        // ── Helpers ─────────────────────────────────────────────
        private static Button MakeIconBtn(string text, Point loc, Size sz)
        {
            var b = new Button
            {
                Text = text,
                Location = loc,
                Size = sz,
                FlatStyle = FlatStyle.Flat,
                ForeColor = C_TXT,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                TabStop = false,
                Font = new Font("Segoe UI", 11f),
            };
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 55);
            return b;
        }

        private static GraphicsPath MakeRoundRect(Rectangle r, int rad)
        {
            int d = rad * 2;
            var p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        // ── Animation ───────────────────────────────────────────
        public async void SlideIn()
        {
            Visible = true; Opacity = 0;
            for (double o = 0; o <= 1; o += 0.1) { Opacity = o; await Task.Delay(16); }
            Opacity = 1;
            _rtb.Focus();
        }

        public async void SlideOut()
        {
            for (double o = 1; o >= 0; o -= 0.12) { Opacity = o; await Task.Delay(14); }
            Visible = false; Opacity = 1;
        }

        // ── Form paint (border) ─────────────────────────────────
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var pen = new Pen(Color.FromArgb(55, 55, 65)))
            using (var path = MakeRoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 12))
                e.Graphics.DrawPath(pen, path);
        }

        protected override CreateParams CreateParams
        {
            get { var cp = base.CreateParams; cp.ClassStyle |= 0x20000; return cp; }
        }
    }

    // ═══════════════════════════════════════════════════════════════════
    //  BUBBLE PANEL
    //  Tự đo text, vẽ bubble trái (bot) hoặc phải (user)
    // ═══════════════════════════════════════════════════════════════════
    // ═══════════════════════════════════════════════════════════════════
    //  BUBBLE PANEL — bôi chọn text được, bubble shape vẽ bằng Region
    //  Dùng RichTextBox readonly bên trong để chọn/copy text
    // ═══════════════════════════════════════════════════════════════════
    public class BubblePanel : Panel
    {
        private readonly bool _user;
        private readonly bool _isTyping;

        // Typing animation
        private System.Windows.Forms.Timer _anim;
        private int _dot = 0;

        // Selectable text box
        private RichTextBox _rtb;

        private static readonly Font FONT = new Font("Segoe UI", 9.5f);
        private static readonly Color C_UBG = Color.FromArgb(50, 50, 64);
        private static readonly Color C_UTXT = Color.FromArgb(215, 215, 224);
        private static readonly Color C_BBG = Color.FromArgb(22, 22, 26);  // = body bg
        private static readonly Color C_BTXT = Color.FromArgb(190, 190, 202);
        private static readonly Color C_BBORD = Color.FromArgb(46, 46, 58);
        private static readonly Color C_DOFF = Color.FromArgb(80, 80, 95);
        private static readonly Color C_DON = Color.FromArgb(160, 160, 180);
        private const int PAD = 11;
        private const int RAD = 14;

        public BubblePanel(string text, bool user, bool isTyping, int containerWidth)
        {
            _user = user;
            _isTyping = isTyping;
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Width = containerWidth;

            if (isTyping)
            {
                Height = 44;
                _anim = new System.Windows.Forms.Timer { Interval = 320 };
                _anim.Tick += (s, e) => { _dot = (_dot + 1) % 4; Invalidate(); };
                _anim.Start();
                return;
            }

            // Đo kích thước bubble
            int maxBubble = (int)(containerWidth * 0.74f);
            int bubbleW, bubbleH;
            using (var g = Graphics.FromHwnd(IntPtr.Zero))
            using (var sf = new StringFormat())
            {
                var sz = g.MeasureString(text, FONT, maxBubble - PAD * 2, sf);
                bubbleW = Math.Min((int)sz.Width + PAD * 2 + 6, maxBubble);
                bubbleH = Math.Max(36, (int)sz.Height + PAD * 2 - 2);
            }

            Height = bubbleH;

            // RichTextBox readonly — để bôi chọn và copy text
            int rtbX = user ? (containerWidth - bubbleW + PAD) : PAD;
            _rtb = new RichTextBox
            {
                Text = text,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.None,
                BackColor = user ? C_UBG : Color.FromArgb(22, 22, 26),
                ForeColor = user ? C_UTXT : C_BTXT,
                Font = FONT,
                WordWrap = true,
                Cursor = Cursors.IBeam,
                Location = new Point(rtbX, PAD / 2 + 1),
                Size = new Size(bubbleW - PAD * 2, bubbleH - PAD),
                TabStop = false,
                ImeMode = ImeMode.Disable,
            };
            // Không cho edit khi double-click
            _rtb.KeyDown += (s, e) =>
            {
                if (e.Control && e.KeyCode == Keys.C) return; // allow copy
                if (e.Control && e.KeyCode == Keys.A) return; // allow select all
                e.SuppressKeyPress = true;
            };

            Controls.Add(_rtb);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_isTyping)
            {
                var r = new Rectangle(0, 4, 58, 34);
                DrawShape(g, r, false);
                int cy = r.Y + r.Height / 2;
                int[] xs = { 15, 27, 39 };
                for (int i = 0; i < 3; i++)
                {
                    bool on = (_dot % 3) == i; int sz = on ? 6 : 4;
                    using (var b = new SolidBrush(on ? C_DON : C_DOFF))
                        g.FillEllipse(b, xs[i] - sz / 2, cy - sz / 2, sz, sz);
                }
                return;
            }

            if (_rtb == null) return;
            int maxBubble = (int)(Width * 0.74f);
            int bW = _rtb.Width + PAD * 2;
            int bH = Height;
            var rect = _user
                ? new Rectangle(Width - bW, 0, bW, bH)
                : new Rectangle(0, 0, bW, bH);
            DrawShape(g, rect, _user);
        }

        private void DrawShape(Graphics g, Rectangle r, bool user)
        {
            int tlR = user ? RAD : 4, trR = user ? 4 : RAD;
            using (var path = new GraphicsPath())
            {
                path.AddArc(r.X, r.Y, tlR * 2, tlR * 2, 180, 90);
                path.AddArc(r.Right - trR * 2, r.Y, trR * 2, trR * 2, 270, 90);
                path.AddArc(r.Right - RAD * 2, r.Bottom - RAD * 2, RAD * 2, RAD * 2, 0, 90);
                path.AddArc(r.X, r.Bottom - RAD * 2, RAD * 2, RAD * 2, 90, 90);
                path.CloseFigure();
                using (var b = new SolidBrush(user ? C_UBG : Color.FromArgb(22, 22, 26)))
                    g.FillPath(b, path);

            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) { _anim?.Stop(); _anim?.Dispose(); _rtb?.Dispose(); }
            base.Dispose(disposing);
        }
    }
    // ═══════════════════════════════════════════════════════════════════
    //  PLACEHOLDER RICHTEXTBOX
    //  - KHÔNG override WndProc (phá IME tiếng Việt)
    //  - Dùng Label trong suốt đặt DƯỚI RTB (không Dock, absolute position)
    //    Label chỉ visible khi Text rỗng, pointer-events = none → không block input
    // ═══════════════════════════════════════════════════════════════════
    public class PlaceholderRtb : RichTextBox
    {
        public string Placeholder { get; set; } = "";

        private Label _hint;

        public PlaceholderRtb()
        {
            ImeMode = ImeMode.On;   // bật IME tiếng Việt
        }

        // Gọi sau khi control được thêm vào parent
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (Parent == null || _hint != null) return;

            _hint = new Label
            {
                Text = Placeholder,
                Font = Font,
                ForeColor = Color.FromArgb(68, 68, 80),
                BackColor = Color.Transparent,
                AutoSize = false,
                // Dùng SendToBack — nằm sau RTB nên không block chuột/bàn phím
            };

            Parent.Controls.Add(_hint);
            _hint.SendToBack();
            this.BringToFront();

            // Sync vị trí & size theo RTB
            SyncHint();
            LocationChanged += (s, ev) => SyncHint();
            SizeChanged += (s, ev) => SyncHint();
            TextChanged += (s, ev) => _hint.Visible = string.IsNullOrEmpty(Text);
            GotFocus += (s, ev) => _hint.Visible = false;
            LostFocus += (s, ev) => _hint.Visible = string.IsNullOrEmpty(Text);
        }

        private void SyncHint()
        {
            if (_hint == null || Parent == null) return;
            _hint.Location = new Point(Left + 4, Top + 6);
            _hint.Size = new Size(Width - 8, Height);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _hint != null)
            {
                Parent?.Controls.Remove(_hint);
                _hint.Dispose();
                _hint = null;
            }
            base.Dispose(disposing);
        }
    }

    // ═══════════════════════════════════════════════════════════════════
    //  ROUND BUTTON — nút tròn hoàn toàn, vẽ bằng GDI+
    // ═══════════════════════════════════════════════════════════════════
    public class RoundButton : Button
    {
        private bool _hover;
        private static readonly Color BG = Color.FromArgb(255, 140, 0);      // Orange
        private static readonly Color BG_HOV = Color.FromArgb(255, 165, 40); // Hover sáng hơn
        private static readonly Color BG_DIS = Color.FromArgb(120, 85, 40);  // Disabled

        public RoundButton()
        {
            FlatStyle = FlatStyle.Flat;
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                   | ControlStyles.SupportsTransparentBackColor, true);
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            BackColor = Color.Transparent;
            MouseEnter += (s, e) => { _hover = true; Invalidate(); };
            MouseLeave += (s, e) => { _hover = false; Invalidate(); };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            // Vẽ nền parent để xóa góc vuông
            if (Parent != null)
            {
                using (var b = new SolidBrush(Parent.BackColor))
                    g.FillRectangle(b, 0, 0, Width, Height);
            }

            // Vẽ hình tròn hoàn hảo
            int pad = 1;
            var rect = new RectangleF(pad, pad, Width - pad * 2 - 1, Height - pad * 2 - 1);
            var bg = !Enabled ? BG_DIS : _hover ? BG_HOV : BG;
            using (var b = new SolidBrush(bg))
                g.FillEllipse(b, rect);

            // Text
            if (!string.IsNullOrEmpty(Text))
            {
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var b = new SolidBrush(Enabled ? ForeColor : Color.FromArgb(75, 75, 92)))
                    g.DrawString(Text, Font, b, new RectangleF(0, 0, Width, Height), sf);
            }
        }

        protected override bool ShowFocusCues => false;
    }

}