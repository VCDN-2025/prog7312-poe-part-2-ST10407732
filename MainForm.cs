using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainForm : Form
    {
        // --- Modern color palette ---
        private static readonly Color PrimaryTeal = Color.FromArgb(0, 123, 139);
        private static readonly Color SecondaryTeal = Color.FromArgb(0, 150, 167);
        private static readonly Color AccentBlue = Color.FromArgb(21, 101, 192);
        private static readonly Color LightTeal = Color.FromArgb(224, 247, 250);
        private static readonly Color DarkGray = Color.FromArgb(66, 66, 66);
        private static readonly Color LightGray = Color.FromArgb(248, 249, 250);
        private static readonly Color BorderGray = Color.FromArgb(224, 224, 224);
        private static readonly Color SuccessGreen = Color.FromArgb(76, 175, 80);
        private static readonly Color WarningOrange = Color.FromArgb(255, 152, 0);
        private static readonly Color ErrorRed = Color.FromArgb(244, 67, 54);
        private static readonly Color StatsYellow = Color.FromArgb(255, 193, 7);

        public MainForm()
        {
            InitializeComponent();
            BuildCustomUI();
        }

        private void BuildCustomUI()
        {
            this.BackColor = LightGray;

            // --- NAV PANEL (top) ---
            Panel navPanel = new Panel { Dock = DockStyle.Top, Height = 80 };
            navPanel.Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    navPanel.ClientRectangle, PrimaryTeal, SecondaryTeal, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, navPanel.ClientRectangle);
                }
            };

            FlowLayoutPanel navButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(12, 12, 12, 12),
                BackColor = Color.Transparent
            };

            navButtons.Controls.Add(CreateNavButton("Accounts", "💳", PrimaryTeal, SecondaryTeal));
            navButtons.Controls.Add(CreateNavButton("Billing", "🧾", Color.FromArgb(0, 105, 92), Color.FromArgb(0, 121, 107)));
            navButtons.Controls.Add(CreateNavButton("Load Shedding", "💡", WarningOrange, Color.FromArgb(255, 167, 38)));
            navButtons.Controls.Add(CreateNavButton("Water & Sanitation", "🚰", SuccessGreen, Color.FromArgb(102, 187, 106)));
            navButtons.Controls.Add(CreateNavButton("E-Services", "🛠️", AccentBlue, Color.FromArgb(48, 123, 204)));
            navButtons.Controls.Add(CreateNavButton("Report Fraud", "🚨", ErrorRed, Color.FromArgb(245, 89, 76)));

            navPanel.Controls.Add(navButtons);
            this.Controls.Add(navPanel);
            this.Controls.SetChildIndex(navPanel, 0);

            // -------- Header content --------
            headerPlaceholder.Controls.Clear();
            headerPlaceholder.Padding = new Padding(16);

            Panel logoContainer = new Panel { Dock = DockStyle.Left, Width = 120, Padding = new Padding(8) };
            logoContainer.Paint += (s, e) =>
            {
                var rect = new Rectangle(0, 0, logoContainer.Width, logoContainer.Height);
                var path = GetRoundedRectanglePath(rect, 12);
                using (var brush = new SolidBrush(LightTeal))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }
            };

            if (this.picLogo != null)
            {
                this.picLogo.Dock = DockStyle.Fill;
                logoContainer.Controls.Add(this.picLogo);

                try
                {
                    string logoPath = @"C:\Users\davyc\source\repos\MunicipalServicesApp\MunicipalityLogo.png";
                    if (System.IO.File.Exists(logoPath))
                        this.picLogo.Image = Image.FromFile(logoPath);
                }
                catch { }
            }

            Panel titleStack = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16) };

            Label lblWelcome = new Label
            {
                Text = "Welcome to Municipal Services",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = DarkGray,
                Height = 48,
                TextAlign = ContentAlignment.BottomLeft
            };

            Label lblSub = new Label
            {
                Text = "Your digital gateway to community services",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(117, 117, 117),
                Height = 28,
                TextAlign = ContentAlignment.TopLeft
            };

            titleStack.Controls.Add(lblSub);
            titleStack.Controls.Add(lblWelcome);
            headerPlaceholder.Controls.Add(titleStack);
            headerPlaceholder.Controls.Add(logoContainer);

            // -------- Progress area --------
            progressPlaceholder.Controls.Clear();
            progressPlaceholder.Padding = new Padding(20, 12, 20, 12);
            if (this.progressBar != null)
            {
                this.progressBar.Dock = DockStyle.Fill;
                this.progressBar.Value = 40;
                progressPlaceholder.Controls.Add(this.progressBar);
            }

            // -------- Cards area --------
            cardsPlaceholder.Controls.Clear();
            TableLayoutPanel cardsPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                Padding = new Padding(20),
                BackColor = LightGray
            };
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));

            // UPDATED: Local Events card now has click handler and is enabled
            cardsPanel.Controls.Add(CreateModernCard("📝 Report an Issue", "Log faults with photos & location", WarningOrange, this.btnReportIssue_Click, false), 0, 0);
            cardsPanel.Controls.Add(CreateModernCard("📢 Local Events", "Community happenings & notices", SuccessGreen, this.btnLocalEvents_Click, false), 1, 0);
            cardsPanel.Controls.Add(CreateModernCard("📊 Service Status", "Track progress of your service requests", AccentBlue, null, true), 2, 0);

            cardsPlaceholder.Controls.Add(cardsPanel);

            // -------- Stats area --------
            statsPlaceholder.Controls.Clear();
            Panel statsContainer = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25), BackColor = Color.White };
            statsContainer.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(BorderGray, 1), new Rectangle(0, 0, statsContainer.Width - 1, statsContainer.Height - 1));
            };

            Label statsTitle = new Label
            {
                Text = "DID YOU KNOW?",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = AccentBlue,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            FlowLayoutPanel statsFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoScroll = true,
                Padding = new Padding(10),
                BackColor = Color.Transparent
            };
            statsFlow.Controls.Add(CreateStatsCard("15", "YEARS SERVING\nOUR COMMUNITY"));
            statsFlow.Controls.Add(CreateStatsCard("125K", "REGISTERED\nCITIZEN ACCOUNTS"));
            statsFlow.Controls.Add(CreateStatsCard("850", "MUNICIPAL\nEMPLOYEES"));
            statsFlow.Controls.Add(CreateStatsCard("2.2K", "FREE WI-FI\nHOTSPOTS"));

            statsContainer.Controls.Add(statsFlow);
            statsContainer.Controls.Add(statsTitle);
            statsPlaceholder.Controls.Add(statsContainer);

            // -------- Footer area --------
            footerPlaceholder.Controls.Clear();
            Panel footer = new Panel { Dock = DockStyle.Fill };
            footer.Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(footer.ClientRectangle, PrimaryTeal, SecondaryTeal, LinearGradientMode.Horizontal))
                    e.Graphics.FillRectangle(brush, footer.ClientRectangle);
            };

            Label footerLabel = new Label
            {
                Text = "📞 Contact: 0800-123-456  |  ✉️ info@municipality.gov.za  |  © 2025 Municipal Services - Serving Our Community",
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                BackColor = Color.Transparent
            };
            footer.Controls.Add(footerLabel);
            footerPlaceholder.Controls.Add(footer);
        }

        private Button CreateNavButton(string text, string emoji, Color bgColor, Color hoverColor)
        {
            Button btn = new Button
            {
                Text = $"{emoji}\n{text}",
                Width = 130,
                Height = 65,
                BackColor = bgColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Margin = new Padding(6, 3, 6, 3),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;

            btn.Paint += (s, e) =>
            {
                var rect = new Rectangle(2, 2, btn.Width - 4, btn.Height - 4);
                var path = GetRoundedRectanglePath(rect, 6);
                using (var brush = new SolidBrush(btn.BackColor))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font,
                    new Rectangle(0, 0, btn.Width, btn.Height), btn.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            btn.MouseEnter += (s, e) => { btn.BackColor = hoverColor; btn.Invalidate(); };
            btn.MouseLeave += (s, e) => { btn.BackColor = bgColor; btn.Invalidate(); };
            return btn;
        }

        private Panel CreateStatsCard(string number, string description)
        {
            Panel statsCard = new Panel { Width = 170, Height = 85, BackColor = StatsYellow, Margin = new Padding(15) };
            statsCard.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, statsCard.Width, statsCard.Height);
                var path = GetRoundedRectanglePath(rect, 8);
                using (var brush = new SolidBrush(StatsYellow))
                    e.Graphics.FillPath(brush, path);
            };

            Label numberLabel = new Label
            {
                Text = number,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 35
            };
            Label descLabel = new Label
            {
                Text = description,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            statsCard.Controls.Add(descLabel);
            statsCard.Controls.Add(numberLabel);
            return statsCard;
        }

        private Panel CreateModernCard(string title, string description, Color accentColor,
                                       EventHandler clickHandler = null, bool comingSoon = false)
        {
            Panel card = new Panel
            {
                Width = 300,
                Height = 160,
                Margin = new Padding(10),
                Cursor = comingSoon ? Cursors.Default : Cursors.Hand
            };

            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(2, 2, card.Width - 4, card.Height - 4);
                var path = GetRoundedRectanglePath(rect, 12);
                using (var brush = new SolidBrush(Color.White))
                    e.Graphics.FillPath(brush, path);
                using (var borderPen = new Pen(BorderGray, 1))
                    e.Graphics.DrawPath(borderPen, path);

                using (var accentBrush = new SolidBrush(accentColor))
                    e.Graphics.FillRectangle(accentBrush, 0, 0, card.Width, 6);
            };

            Label lblTitle = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 40,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = comingSoon ? Color.DarkGray : DarkGray,
                BackColor = Color.Transparent
            };

            Label lblDesc = new Label
            {
                Text = description,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10),
                ForeColor = comingSoon ? Color.Gray : Color.FromArgb(117, 117, 117),
                BackColor = Color.Transparent
            };

            Label lblAction = new Label
            {
                Text = comingSoon ? "🚧 Coming Soon" : "Click to access →",
                Dock = DockStyle.Bottom,
                Height = 25,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = comingSoon ? Color.Gray : accentColor,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };

            card.Controls.Add(lblDesc);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblAction);

            if (!comingSoon && clickHandler != null)
            {
                lblTitle.Click += clickHandler;
                lblDesc.Click += clickHandler;
                lblAction.Click += clickHandler;
                card.Click += clickHandler;
            }

            return card;
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (this.progressBar != null)
                this.progressBar.Value = 40;
        }

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportIssueForm reportForm = new ReportIssueForm();
            reportForm.FormClosed += (s, args) => this.Show();
            reportForm.Show();
        }

        // NEW: Local Events click handler
        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            this.Hide();
            EventsAndAnnouncementsForm eventsForm = new EventsAndAnnouncementsForm();
            eventsForm.FormClosed += (s, args) => this.Show();
            eventsForm.Show();
        }

        private void headerPlaceholder_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}