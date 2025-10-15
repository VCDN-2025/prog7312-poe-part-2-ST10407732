using MunicipalServicesApp.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public class MyReportsForm : Form
    {
        private IssueLinkedList allIssues;
        private string CurrentUserId;

        private Panel mainPanel;
        private Panel navPanel;
        private FlowLayoutPanel navButtons;
        private Panel footerPanel;
        private Label lblFooter;
        private Panel engagementPanel;

        // Modern color palette
        private static readonly Color PrimaryTeal = Color.FromArgb(0, 123, 139);
        private static readonly Color SecondaryTeal = Color.FromArgb(0, 150, 167);
        private static readonly Color SuccessGreen = Color.FromArgb(76, 175, 80);
        private static readonly Color WarningOrange = Color.FromArgb(255, 152, 0);
        private static readonly Color ErrorRed = Color.FromArgb(244, 67, 54);
        private static readonly Color AccentBlue = Color.FromArgb(21, 101, 192);
        private static readonly Color LightGray = Color.FromArgb(248, 249, 250);
        private static readonly Color DarkGray = Color.FromArgb(66, 66, 66);
        private static readonly Color BorderGray = Color.FromArgb(224, 224, 224);

        public MyReportsForm(IssueLinkedList issues, string currentUserId)
        {
            allIssues = issues;
            CurrentUserId = currentUserId;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "📊 My Reports";
            this.Size = new Size(1000, 700);
            this.MinimumSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = LightGray;

            // ===== Nav Panel =====
            navPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 85,
                BackColor = PrimaryTeal
            };
            navPanel.Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(navPanel.ClientRectangle, PrimaryTeal, SecondaryTeal, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, navPanel.ClientRectangle);
                }
            };
            this.Controls.Add(navPanel);

            navButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(15, 12, 15, 12),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            navPanel.Controls.Add(navButtons);

            navButtons.Controls.Add(CreateNavButton("Accounts", "💳", PrimaryTeal, SecondaryTeal));
            navButtons.Controls.Add(CreateNavButton("Billing", "🧾", Color.FromArgb(0, 105, 92), Color.FromArgb(0, 121, 107)));
            navButtons.Controls.Add(CreateNavButton("Load Shedding", "💡", WarningOrange, Color.FromArgb(255, 167, 38)));
            navButtons.Controls.Add(CreateNavButton("Water & Sanitation", "🚰", SuccessGreen, Color.FromArgb(102, 187, 106)));
            navButtons.Controls.Add(CreateNavButton("E-Services", "🛠️", AccentBlue, Color.FromArgb(48, 123, 204)));
            navButtons.Controls.Add(CreateNavButton("Report Fraud", "🚨", ErrorRed, Color.FromArgb(245, 89, 76)));

            // ===== Main Scrollable Panel =====
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10)
            };
            this.Controls.Add(mainPanel);

            // ===== Footer =====
            footerPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = PrimaryTeal,
                Padding = new Padding(15)
            };
            footerPanel.Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(footerPanel.ClientRectangle, PrimaryTeal, SecondaryTeal, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, footerPanel.ClientRectangle);
                }
            };
            lblFooter = new Label
            {
                Text = "📞 Contact: 0800-123-456  |  ✉️ info@municipality.gov.za  |  © 2025 Municipal Services - Serving Our Community",
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            footerPanel.Controls.Add(lblFooter);
            this.Controls.Add(footerPanel);

            // ===== Load Reports =====
            LoadUserReports();

            // Keep controls centered when resizing
            mainPanel.Resize += (s, e) => CenterMainContent();
        }

        private void LoadUserReports()
        {
            mainPanel.Controls.Clear();

            var issues = allIssues.ToArray();
            int userReportCount = issues.Count(i => i.UserId == CurrentUserId);

            // ===== Heading =====
            Label lblHeading = new Label
            {
                Text = "📊 My Reports",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = DarkGray,
                AutoSize = true,
                Tag = "heading"
            };
            mainPanel.Controls.Add(lblHeading);

            // ===== "Report an Issue" Button =====
            Button btnReportIssue = new Button
            {
                Text = "📝 Report an Issue",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = AccentBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 45),
                Cursor = Cursors.Hand,
                Tag = "reportButton"
            };
            btnReportIssue.FlatAppearance.BorderSize = 0;
            btnReportIssue.Click += (s, e) =>
            {
                ReportIssueForm reportForm = new ReportIssueForm();
                reportForm.Show();
                this.Close();
            };
            mainPanel.Controls.Add(btnReportIssue);

            // ===== Engagement / "Did You Know?" Section =====
            engagementPanel = new Panel
            {
                Size = new Size(mainPanel.ClientSize.Width - 200, 70),
                BackColor = Color.LightGray,
                Tag = "engagement"
            };
            mainPanel.Controls.Add(engagementPanel);
            ShowUserEngagement(userReportCount);

            // ===== Reports =====
            int yPos = 400;
            foreach (var issue in issues.Where(i => i.UserId == CurrentUserId))
            {
                Panel reportPanel = new Panel
                {
                    Size = new Size(mainPanel.ClientSize.Width - 100, 150),
                    BackColor = Color.AliceBlue,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand,
                    Location = new Point(50, yPos)
                };
                reportPanel.Click += (s, e) => ShowReportDetails(issue);

                reportPanel.Controls.Add(new Label { Text = $"Category: {issue.Category}", Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(10, 10), AutoSize = true });
                reportPanel.Controls.Add(new Label { Text = $"Date: {issue.DateReported.ToShortDateString()}", Font = new Font("Segoe UI", 9), Location = new Point(10, 30), AutoSize = true });
                // FIXED: Changed from issue.Location to issue.FullLocation
                reportPanel.Controls.Add(new Label { Text = $"Location: {issue.FullLocation}", Font = new Font("Segoe UI", 9), Location = new Point(10, 50), AutoSize = true });
                reportPanel.Controls.Add(new Label { Text = $"Description: {issue.Description}", Font = new Font("Segoe UI", 9), Location = new Point(10, 70), Size = new Size(reportPanel.Width - 20, 60) });

                mainPanel.Controls.Add(reportPanel);
                yPos += 170;
            }

            CenterMainContent();
        }

        private void CenterMainContent()
        {
            var lblHeading = mainPanel.Controls.OfType<Label>().FirstOrDefault(c => c.Tag?.ToString() == "heading");
            var btnReport = mainPanel.Controls.OfType<Button>().FirstOrDefault(c => c.Tag?.ToString() == "reportButton");
            var engagement = mainPanel.Controls.OfType<Panel>().FirstOrDefault(c => c.Tag?.ToString() == "engagement");

            if (lblHeading != null)
                lblHeading.Location = new Point((mainPanel.ClientSize.Width - lblHeading.Width) / 2, 150);

            if (btnReport != null && lblHeading != null)
                btnReport.Location = new Point((mainPanel.ClientSize.Width - btnReport.Width) / 2, lblHeading.Bottom + 20);

            if (engagement != null && btnReport != null)
                engagement.Location = new Point((mainPanel.ClientSize.Width - engagement.Width) / 2, btnReport.Bottom + 30);
        }

        private void ShowUserEngagement(int userReportCount)
        {
            engagementPanel.Controls.Clear();

            string badge;
            Color bgColor;
            string message;

            if (userReportCount == 0)
            {
                badge = "🔹";
                message = "No reports yet. Start making an impact!";
                bgColor = Color.LightGray;
            }
            else if (userReportCount < 5)
            {
                badge = "🥉 Bronze";
                int remaining = 5 - userReportCount;
                message = $"You have submitted {userReportCount} report(s). {remaining} more to reach Silver 🥉!";
                bgColor = Color.SandyBrown;
            }
            else if (userReportCount < 10)
            {
                badge = "🥈 Silver";
                int remaining = 10 - userReportCount;
                message = $"Great work! {userReportCount} reports submitted. {remaining} more to reach Gold 🥈!";
                bgColor = Color.Silver;
            }
            else if (userReportCount < 15)
            {
                badge = "🥇 Gold";
                int remaining = 15 - userReportCount;
                message = $"Awesome! {userReportCount} reports submitted. {remaining} more to reach Platinum 🥇!";
                bgColor = Color.Gold;
            }
            else
            {
                badge = "🏆 Platinum";
                message = $"🌟 Super Contributor! {userReportCount} reports submitted! Keep shining! 🏆";
                bgColor = Color.LightGreen;
            }

            engagementPanel.BackColor = bgColor;

            Label lblEngagement = new Label
            {
                Text = $"{badge} - {message}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            engagementPanel.Controls.Add(lblEngagement);
        }

        private void ShowReportDetails(Issue issue)
        {
            Form detailForm = new Form
            {
                Text = "Report Details",
                Size = new Size(600, 500),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.WhiteSmoke
            };

            int yPos = 10;
            void AddLabel(string text, int top)
            {
                detailForm.Controls.Add(new Label
                {
                    Text = text,
                    Font = new Font("Segoe UI", 10),
                    Location = new Point(10, top),
                    AutoSize = true
                });
            }

            AddLabel($"Category: {issue.Category}", yPos); yPos += 25;
            AddLabel($"Date: {issue.DateReported}", yPos); yPos += 25;
            // FIXED: Changed from issue.Location to issue.FullLocation
            AddLabel($"Location: {issue.FullLocation}", yPos); yPos += 25;
            AddLabel($"Description: {issue.Description}", yPos); yPos += 40;

            if (issue.AttachedFiles != null && issue.AttachedFiles.Length > 0)
            {
                AddLabel("Attachments:", yPos); yPos += 25;
                foreach (var file in issue.AttachedFiles)
                {
                    if (System.IO.File.Exists(file))
                    {
                        PictureBox pb = new PictureBox
                        {
                            Image = Image.FromFile(file),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Size = new Size(200, 150),
                            Location = new Point(10, yPos)
                        };
                        detailForm.Controls.Add(pb);
                        yPos += 160;
                    }
                }
            }

            detailForm.ShowDialog();
        }

        private Button CreateNavButton(string text, string emoji, Color bgColor, Color hoverColor)
        {
            Button btn = new Button
            {
                Text = $"{emoji}\n{text}",
                Width = 130,
                Height = 65,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = bgColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Margin = new Padding(6, 3, 6, 3),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };

            btn.Paint += (s, e) =>
            {
                var rect = new Rectangle(2, 2, btn.Width - 4, btn.Height - 4);
                var path = GetRoundedRectanglePath(rect, 8);
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

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MyReportsForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "MyReportsForm";
            this.Load += new System.EventHandler(this.MyReportsForm_Load);
            this.ResumeLayout(false);
        }

        private void MyReportsForm_Load(object sender, EventArgs e)
        {

        }
    }
}