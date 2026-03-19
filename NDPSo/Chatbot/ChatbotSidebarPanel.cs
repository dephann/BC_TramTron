using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.Chatbot
{
    public class ChatbotSidebarPanel : DevExpress.XtraEditors.XtraUserControl
    {
        // ── Controls ──────────────────────────────────────────
        private Panel _pnlHeader;
        private Label _lblTitle;
        private Label _lblStatus;
        private Button _btnToggle;         // Thu gọn / Mở rộng sidebar
        private RichTextBox _rtbChat;      // Hiển thị lịch sử chat
        private Panel _pnlInput;
        private TextBox _txtInput;
        private Button _btnSend;
        private Button _btnClear;
        private Panel _pnlSqlDebug;        // Panel xem SQL đã chạy (ẩn/hiện)
        private RichTextBox _rtbSql;
        private Button _btnToggleSql;
        private ProgressBar _progressBar;
        // ── Services ──────────────────────────────────────────
        private ChatbotOrchestrator _orchestrator;
        private bool _isProcessing = false;
        private bool _showSqlDebug = false;
        // ── Colors ────────────────────────────────────────────
        private readonly Color _colorHeader = Color.FromArgb(30, 58, 95);
        private readonly Color _colorBackground = Color.FromArgb(245, 247, 250);
        private readonly Color _colorUserBubble = Color.FromArgb(30, 58, 95);
        private readonly Color _colorBotBubble = Color.White;
        private readonly Color _colorAccent = Color.FromArgb(52, 152, 219);
        private readonly Color _colorSendBtn = Color.FromArgb(39, 174, 96);

        public ChatbotSidebarPanel()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Khởi tạo với API key và connection string
        /// Gọi sau khi add control vào form
        /// </summary>
        public void Initialize(string claudeApiKey, string sqlConnectionString)
        {
            _orchestrator = new ChatbotOrchestrator(claudeApiKey, sqlConnectionString);
            _orchestrator.OnStatusChanged += status =>
            {
                if (InvokeRequired)
                    Invoke(new Action<string>(UpdateStatus), status);
                else
                    UpdateStatus(status);
            };

            // Kiểm tra kết nối DB
            if (_orchestrator.TestDatabaseConnection())
                UpdateStatus("✅ Kết nối DB thành công");
            else
                UpdateStatus("❌ Lỗi kết nối DB");

            AppendWelcomeMessage();
        }

        // ══════════════════════════════════════════════════════
        //  KHỞI TẠO UI
        // ══════════════════════════════════════════════════════
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Width = 380;
            this.Dock = DockStyle.Right;
            this.BackColor = _colorBackground;
            this.BorderStyle = BorderStyle.FixedSingle;

            BuildHeader();
            BuildProgressBar();
            BuildChatArea();
            BuildSqlDebugPanel();
            BuildInputArea();

            this.ResumeLayout(false);
        }

        private void BuildHeader()
        {
            _pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 56,
                BackColor = _colorHeader,
                Padding = new Padding(12, 0, 8, 0)
            };

            // Icon + Title
            _lblTitle = new Label
            {
                Text = "🤖  Trợ lý AI Trạm Trộn",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                AutoSize = false,
                Width = 260,
                Height = 56,
                Location = new Point(10, 0),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Nút thu gọn
            _btnToggle = new Button
            {
                Text = "◀",
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f),
                Size = new Size(32, 32),
                Location = new Point(330, 12),
                Cursor = Cursors.Hand,
                TabStop = false
            };
            _btnToggle.FlatAppearance.BorderSize = 0;
            _btnToggle.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 255, 255, 255);
            _btnToggle.Click += BtnToggle_Click;

            _pnlHeader.Controls.Add(_lblTitle);
            _pnlHeader.Controls.Add(_btnToggle);
            this.Controls.Add(_pnlHeader);

            // Status bar
            _lblStatus = new Label
            {
                Dock = DockStyle.Top,
                Height = 22,
                BackColor = Color.FromArgb(220, 230, 241),
                ForeColor = Color.FromArgb(52, 73, 94),
                Font = new Font("Segoe UI", 8f),
                Text = "Đang khởi tạo...",
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(8, 0, 0, 0)
            };
            this.Controls.Add(_lblStatus);
        }

        private void BuildProgressBar()
        {
            _progressBar = new ProgressBar
            {
                Dock = DockStyle.Top,
                Height = 3,
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
                Visible = false
            };
            this.Controls.Add(_progressBar);
        }

        private void BuildChatArea()
        {
            _rtbChat = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = _colorBackground,
                ForeColor = Color.FromArgb(44, 62, 80),
                Font = new Font("Segoe UI", 10f),
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                Padding = new Padding(8),
                WordWrap = true
            };
            this.Controls.Add(_rtbChat);
        }

        private void BuildSqlDebugPanel()
        {
            _pnlSqlDebug = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 120,
                BackColor = Color.FromArgb(30, 39, 46),
                Visible = false
            };

            _btnToggleSql = new Button
            {
                Text = "SQL »",
                Dock = DockStyle.Bottom,
                Height = 22,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(44, 62, 80),
                ForeColor = Color.FromArgb(149, 165, 166),
                Font = new Font("Segoe UI", 8f),
                Cursor = Cursors.Hand,
                TabStop = false
            };
            _btnToggleSql.FlatAppearance.BorderSize = 0;
            _btnToggleSql.Click += BtnToggleSql_Click;

            _rtbSql = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(30, 39, 46),
                ForeColor = Color.FromArgb(127, 219, 202),
                Font = new Font("Consolas", 8.5f),
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.Both,
                WordWrap = false
            };

            _pnlSqlDebug.Controls.Add(_rtbSql);
            this.Controls.Add(_pnlSqlDebug);
            this.Controls.Add(_btnToggleSql);
        }

        private void BuildInputArea()
        {
            _pnlInput = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(8, 8, 8, 8)
            };
            _pnlInput.Paint += (s, e) =>
            {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(220, 220, 220)), 0, 0, _pnlInput.Width, 0);
            };

            _txtInput = new TextBox
            {
                Location = new Point(8, 12),
                Size = new Size(270, 36),
                Font = new Font("Segoe UI", 10f),
                BorderStyle = BorderStyle.FixedSingle,
                ForeColor = Color.FromArgb(44, 62, 80)
            };
            _txtInput.KeyDown += TxtInput_KeyDown;

            _btnSend = new Button
            {
                Text = "Gửi ▶",
                Location = new Point(286, 10),
                Size = new Size(70, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor = _colorSendBtn,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TabStop = false
            };
            _btnSend.FlatAppearance.BorderSize = 0;
            _btnSend.Click += BtnSend_Click;

            _btnClear = new Button
            {
                Text = "Xóa",
                Dock = DockStyle.Bottom,
                Height = 20,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(245, 245, 245),
                ForeColor = Color.FromArgb(150, 150, 150),
                Font = new Font("Segoe UI", 7.5f),
                Cursor = Cursors.Hand,
                TabStop = false
            };
            _btnClear.FlatAppearance.BorderSize = 0;
            _btnClear.Click += (s, e) => ClearChat();

            _pnlInput.Controls.Add(_txtInput);
            _pnlInput.Controls.Add(_btnSend);
            _pnlInput.Controls.Add(_btnClear);
            this.Controls.Add(_pnlInput);
        }

        // ══════════════════════════════════════════════════════
        //  XỬ LÝ SỰ KIỆN
        // ══════════════════════════════════════════════════════
        private async void BtnSend_Click(object sender, EventArgs e)
        {
            await SendMessageAsync();
        }

        private async void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                await SendMessageAsync();
            }
        }

        private async Task SendMessageAsync()
        {
            if (_isProcessing || _orchestrator == null) return;

            var question = _txtInput.Text.Trim();
            if (string.IsNullOrEmpty(question)) return;

            _txtInput.Clear();
            _isProcessing = true;
            SetProcessingState(true);

            // Hiển thị câu hỏi của user
            AppendUserMessage(question);

            // Gọi chatbot
            var result = await _orchestrator.ProcessQuestionAsync(question);

            // Hiển thị câu trả lời
            AppendBotMessage(result.Answer, result.IsSuccess);

            // Cập nhật SQL debug panel
            if (!string.IsNullOrEmpty(result.SqlUsed))
            {
                _rtbSql.Text = result.SqlUsed;
                _btnToggleSql.Text = "SQL (có dữ liệu) »";
                _btnToggleSql.ForeColor = Color.FromArgb(46, 204, 113);
            }
            else
            {
                _rtbSql.Text = "(Không dùng SQL)";
                _btnToggleSql.ForeColor = Color.FromArgb(149, 165, 166);
            }

            SetProcessingState(false);
            _isProcessing = false;
            UpdateStatus("✅ Sẵn sàng");
        }

        private void BtnToggle_Click(object sender, EventArgs e)
        {
            // Thu gọn/mở rộng sidebar
            if (this.Width > 50)
            {
                this.Width = 36;
                _btnToggle.Text = "▶";
                _pnlHeader.Controls.Remove(_lblTitle);
            }
            else
            {
                this.Width = 380;
                _btnToggle.Text = "◀";
                if (!_pnlHeader.Controls.Contains(_lblTitle))
                    _pnlHeader.Controls.Add(_lblTitle);
            }
        }

        private void BtnToggleSql_Click(object sender, EventArgs e)
        {
            _showSqlDebug = !_showSqlDebug;
            _pnlSqlDebug.Visible = _showSqlDebug;
            _btnToggleSql.Text = _showSqlDebug ? "SQL (ẩn) ▲" : "SQL »";
        }

        // ══════════════════════════════════════════════════════
        //  HIỂN THỊ CHAT
        // ══════════════════════════════════════════════════════
        private void AppendWelcomeMessage()
        {
            _rtbChat.SelectionColor = Color.FromArgb(100, 100, 100);
            _rtbChat.SelectionFont = new Font("Segoe UI", 9f, FontStyle.Italic);
            _rtbChat.AppendText("─────────────────────────\n");
            _rtbChat.AppendText("  Xin chào! Tôi là trợ lý AI\n");
            _rtbChat.AppendText("  vận hành trạm trộn của bạn.\n");
            _rtbChat.AppendText("  Hãy đặt câu hỏi về:\n");
            _rtbChat.AppendText("  • Sản lượng, mẻ trộn\n");
            _rtbChat.AppendText("  • Tồn kho nguyên liệu\n");
            _rtbChat.AppendText("  • Giao hàng, khách hàng\n");
            _rtbChat.AppendText("  • Sự kiện, cảnh báo\n");
            _rtbChat.AppendText("─────────────────────────\n\n");
        }

        private void AppendUserMessage(string message)
        {
            _rtbChat.SelectionAlignment = HorizontalAlignment.Right;
            _rtbChat.SelectionBackColor = _colorUserBubble;
            _rtbChat.SelectionColor = Color.White;
            _rtbChat.SelectionFont = new Font("Segoe UI", 10f, FontStyle.Bold);
            _rtbChat.AppendText($" Bạn \n");
            _rtbChat.SelectionFont = new Font("Segoe UI", 10f);
            _rtbChat.AppendText($" {message} \n\n");
            _rtbChat.SelectionBackColor = _colorBackground;
            _rtbChat.SelectionAlignment = HorizontalAlignment.Left;
            ScrollToBottom();
        }

        private void AppendBotMessage(string message, bool isSuccess)
        {
            _rtbChat.SelectionAlignment = HorizontalAlignment.Left;
            _rtbChat.SelectionColor = _colorAccent;
            _rtbChat.SelectionFont = new Font("Segoe UI", 9f, FontStyle.Bold);
            _rtbChat.AppendText(" 🤖 Trợ lý AI\n");
            _rtbChat.SelectionColor = isSuccess ? Color.FromArgb(44, 62, 80) : Color.FromArgb(192, 57, 43);
            _rtbChat.SelectionFont = new Font("Segoe UI", 10f);
            _rtbChat.AppendText($" {message}\n\n");
            ScrollToBottom();
        }

        private void ClearChat()
        {
            _rtbChat.Clear();
            AppendWelcomeMessage();
            _rtbSql.Clear();
        }

        private void ScrollToBottom()
        {
            _rtbChat.SelectionStart = _rtbChat.Text.Length;
            _rtbChat.ScrollToCaret();
        }

        private void UpdateStatus(string status)
        {
            _lblStatus.Text = status;
        }

        private void SetProcessingState(bool processing)
        {
            _btnSend.Enabled = !processing;
            _txtInput.Enabled = !processing;
            _progressBar.Visible = processing;
            _btnSend.Text = processing ? "..." : "Gửi ▶";
        }
    }
}
    
