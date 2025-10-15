using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssueForm : Form
    {
        private string CurrentUserId = "Lungisani";
        private IssueLinkedList issueList;

        // --- Color Palette ---
        private static readonly Color PrimaryTeal = Color.FromArgb(0, 123, 139);
        private static readonly Color SecondaryTeal = Color.FromArgb(0, 150, 167);
        private static readonly Color AccentBlue = Color.FromArgb(21, 101, 192);
        private static readonly Color LightGray = Color.FromArgb(248, 249, 250);
        private static readonly Color DarkGray = Color.FromArgb(66, 66, 66);
        private static readonly Color SuccessGreen = Color.FromArgb(76, 175, 80);

        public ReportIssueForm()
        {
            InitializeComponent();
            this.Load += ReportIssueForm_Load;
        }

        private void ReportIssueForm_Load(object sender, EventArgs e)
        {
            this.BackColor = LightGray;
            this.Size = new Size(1000, 700);

            // Title with emoji
            lblTitle.Text = "📢 Report an Issue";
            lblTitle.ForeColor = PrimaryTeal;
            lblTitle.Height = 60;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Configure main layout
            mainLayout.Padding = new Padding(30);
            mainLayout.RowStyles.Clear();

            // Row styles for better spacing
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));  // Location header
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));  // Province
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));  // City
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));  // Area
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));  // Category
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F)); // Description
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));  // Attachments
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));  // Add button
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));  // Submit buttons

            // Location Header
            lblLocation.Text = "📍 Location";
            lblLocation.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLocation.ForeColor = PrimaryTeal;
            lblLocation.TextAlign = ContentAlignment.MiddleLeft;

            // Province
            Label lblProvLabel = new Label
            {
                Text = "Province:",
                Font = new Font("Segoe UI", 10F),
                ForeColor = DarkGray,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };

            cmbProvince.Font = new Font("Segoe UI", 11F);
            cmbProvince.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProvince.Dock = DockStyle.Fill;
            cmbProvince.SelectedIndexChanged += cmbProvince_SelectedIndexChanged;
            cmbProvince.Items.AddRange(new string[]
            {
                "KwaZulu-Natal",
                "Gauteng",
                "Western Cape",
                "Eastern Cape",
                "Free State",
                "Limpopo",
                "Mpumalanga",
                "North West",
                "Northern Cape"
            });
            cmbProvince.SelectedIndex = 0;

            // City
            Label lblCityLabel = new Label
            {
                Text = "City:",
                Font = new Font("Segoe UI", 10F),
                ForeColor = DarkGray,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };

            cmbCity.Font = new Font("Segoe UI", 11F);
            cmbCity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCity.Dock = DockStyle.Fill;
            cmbCity.SelectedIndexChanged += cmbCity_SelectedIndexChanged;

            // Area
            Label lblAreaLabel = new Label
            {
                Text = "Area:",
                Font = new Font("Segoe UI", 10F),
                ForeColor = DarkGray,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };

            cmbArea.Font = new Font("Segoe UI", 11F);
            cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArea.Dock = DockStyle.Fill;

            // Category
            lblCategory.Text = "📂 Category";
            lblCategory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCategory.ForeColor = DarkGray;
            lblCategory.TextAlign = ContentAlignment.MiddleLeft;

            cmbCategory.Font = new Font("Segoe UI", 11F);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Dock = DockStyle.Fill;
            cmbCategory.Items.AddRange(new string[]
            {
                "🚧 Road Damage",
                "🗑 Waste Management",
                "💧 Water Supply",
                "💡 Electricity",
                "📌 Other"
            });
            cmbCategory.SelectedIndex = 0;

            // Description
            lblDescription.Text = "📝 Description";
            lblDescription.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDescription.ForeColor = DarkGray;
            lblDescription.TextAlign = ContentAlignment.TopLeft;

            rtbDescription.Font = new Font("Segoe UI", 10F);
            rtbDescription.Dock = DockStyle.Fill;

            // Attachments
            lblAttachments.Text = "📎 Attachments";
            lblAttachments.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAttachments.ForeColor = DarkGray;
            lblAttachments.TextAlign = ContentAlignment.TopLeft;

            lstAttachments.Font = new Font("Segoe UI", 9F);
            lstAttachments.Dock = DockStyle.Fill;

            btnAddAttachment.Text = "➕ Add Attachment";
            btnAddAttachment.BackColor = AccentBlue;
            btnAddAttachment.ForeColor = Color.White;
            btnAddAttachment.FlatStyle = FlatStyle.Flat;
            btnAddAttachment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddAttachment.Height = 40;
            btnAddAttachment.Dock = DockStyle.Right;
            btnAddAttachment.Width = 180;
            btnAddAttachment.Click += btnAddAttachment_Click;

            // Buttons Panel
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 50
            };

            btnSubmit.Text = "✅ Submit Issue";
            btnSubmit.BackColor = SuccessGreen;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Size = new Size(180, 45);
            btnSubmit.Location = new Point(0, 5);
            btnSubmit.Click += btnSubmit_Click;

            btnBackToMenu.Text = "⬅ Back to Menu";
            btnBackToMenu.BackColor = PrimaryTeal;
            btnBackToMenu.ForeColor = Color.White;
            btnBackToMenu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBackToMenu.FlatStyle = FlatStyle.Flat;
            btnBackToMenu.Size = new Size(180, 45);
            btnBackToMenu.Location = new Point(200, 5);
            btnBackToMenu.Click += btnBackToMenu_Click;

            buttonPanel.Controls.Add(btnSubmit);
            buttonPanel.Controls.Add(btnBackToMenu);

            // Add controls to layout
            mainLayout.Controls.Clear();
            mainLayout.Controls.Add(lblLocation, 0, 0);
            mainLayout.SetColumnSpan(lblLocation, 2);

            mainLayout.Controls.Add(lblProvLabel, 0, 1);
            mainLayout.Controls.Add(cmbProvince, 1, 1);

            mainLayout.Controls.Add(lblCityLabel, 0, 2);
            mainLayout.Controls.Add(cmbCity, 1, 2);

            mainLayout.Controls.Add(lblAreaLabel, 0, 3);
            mainLayout.Controls.Add(cmbArea, 1, 3);

            mainLayout.Controls.Add(lblCategory, 0, 4);
            mainLayout.Controls.Add(cmbCategory, 1, 4);

            mainLayout.Controls.Add(lblDescription, 0, 5);
            mainLayout.Controls.Add(rtbDescription, 1, 5);

            mainLayout.Controls.Add(lblAttachments, 0, 6);
            mainLayout.Controls.Add(lstAttachments, 1, 6);

            mainLayout.Controls.Add(new Label(), 0, 7);
            mainLayout.Controls.Add(btnAddAttachment, 1, 7);

            mainLayout.Controls.Add(buttonPanel, 0, 8);
            mainLayout.SetColumnSpan(buttonPanel, 2);

            // Engagement
            lblEngagement.Text = "Community engagement tracker...";
            lblEngagement.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblEngagement.ForeColor = DarkGray;
            lblEngagement.TextAlign = ContentAlignment.MiddleCenter;

            // ProgressBar
            progressBar.Height = 25;

            // Side panel
            sidePanel.Dock = DockStyle.Right;
            sidePanel.Width = 200;
            sidePanel.BackColor = SecondaryTeal;

            Button btnMyReports = new Button
            {
                Text = "📊 My Reports",
                Dock = DockStyle.Top,
                Height = 60,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            btnMyReports.FlatAppearance.BorderSize = 0;
            btnMyReports.Click += btnMyReports_Click;

            Button btnHelp = new Button
            {
                Text = "❓ Help",
                Dock = DockStyle.Top,
                Height = 60,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = PrimaryTeal
            };
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.Click += btnHelp_Click;

            sidePanel.Controls.Add(btnHelp);
            sidePanel.Controls.Add(btnMyReports);

            // Load issues
            issueList = IssueStorage.Load();
            UpdateEngagementDisplay();

            // Load logo at runtime
            string logoPath = @"C:\Users\davyc\source\repos\MunicipalServicesApp\MunicipalityLogo.png";
            if (System.IO.File.Exists(logoPath))
                picLogo.Image = Image.FromFile(logoPath);
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCity.Items.Clear();
            cmbArea.Items.Clear();

            switch (cmbProvince.SelectedItem.ToString())
            {
                case "KwaZulu-Natal":
                    cmbCity.Items.AddRange(new string[] { "Durban", "Pietermaritzburg", "Richards Bay" });
                    break;
                case "Gauteng":
                    cmbCity.Items.AddRange(new string[] { "Johannesburg", "Pretoria", "Soweto" });
                    break;
                case "Western Cape":
                    cmbCity.Items.AddRange(new string[] { "Cape Town", "Stellenbosch", "George" });
                    break;
                default:
                    cmbCity.Items.Add("Other");
                    break;
            }

            if (cmbCity.Items.Count > 0)
                cmbCity.SelectedIndex = 0;
        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbArea.Items.Clear();

            switch (cmbCity.SelectedItem.ToString())
            {
                case "Durban":
                    cmbArea.Items.AddRange(new string[] { "Umhlanga", "Berea", "Chatsworth", "Phoenix" });
                    break;
                case "Johannesburg":
                    cmbArea.Items.AddRange(new string[] { "Sandton", "Soweto", "Rosebank", "Randburg" });
                    break;
                case "Cape Town":
                    cmbArea.Items.AddRange(new string[] { "Sea Point", "Khayelitsha", "Bellville", "Mitchells Plain" });
                    break;
                default:
                    cmbArea.Items.Add("Other");
                    break;
            }

            if (cmbArea.Items.Count > 0)
                cmbArea.SelectedIndex = 0;
        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Filter = "Supported Files|*.jpg;*.jpeg;*.png;*.mp4;*.mov;*.avi";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var file in ofd.FileNames)
                        lstAttachments.Items.Add(file);
                }
            }
        }

        private void btnMyReports_Click(object sender, EventArgs e)
        {
            MyReportsForm reportsForm = new MyReportsForm(issueList, CurrentUserId);
            reportsForm.ShowDialog();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbProvince.SelectedItem == null || cmbCity.SelectedItem == null ||
                cmbArea.SelectedItem == null || string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("⚠️ Please provide a complete location and description.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            var issue = new Issue
            {
                Province = cmbProvince.SelectedItem?.ToString() ?? string.Empty,
                City = cmbCity.SelectedItem?.ToString() ?? string.Empty,
                Area = cmbArea.SelectedItem?.ToString() ?? string.Empty,
                Category = cmbCategory.SelectedItem?.ToString() ?? string.Empty,
                Description = rtbDescription.Text.Trim(),
                UserId = CurrentUserId
            };

            string[] attachments = new string[lstAttachments.Items.Count];
            for (int i = 0; i < lstAttachments.Items.Count; i++)
                attachments[i] = IssueStorage.CopyMediaFile(lstAttachments.Items[i].ToString());

            issue.AttachedFiles = attachments;

            issueList.Add(issue);
            IssueStorage.Save(issueList);

            MessageBox.Show("✅ Thank you! Your report has been successfully submitted.",
                            "Submission Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            cmbProvince.SelectedIndex = 0;
            rtbDescription.Clear();
            lstAttachments.Items.Clear();
            cmbCategory.SelectedIndex = 0;

            AnimateProgressBar(issueList.Count());
            UpdateEngagementDisplay();
        }

        private void UpdateEngagementDisplay()
        {
            int percent = EngagementService.ComputePercent(issueList);
            string message = EngagementService.GetMessage(issueList);

            lblEngagement.Text = message;

            if (percent < 30)
            {
                lblEngagement.ForeColor = Color.DimGray;
                lblEngagement.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            }
            else if (percent < 70)
            {
                lblEngagement.ForeColor = Color.DarkOrange;
                lblEngagement.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
            else
            {
                lblEngagement.ForeColor = Color.ForestGreen;
                lblEngagement.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lblEngagement.Text = "🌟 " + message;
            }
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string helpMessage =
                "📌 How to report an issue:\n\n" +
                "1. Select your Province, City, and Area.\n" +
                "2. Select the appropriate category for the issue.\n" +
                "3. Describe the issue clearly.\n" +
                "4. Add any relevant attachments.\n" +
                "5. Click 'Submit Issue' to send your report.";

            MessageBox.Show(helpMessage, "Help - Reporting Issues",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void AnimateProgressBar(int issueCount)
        {
            int targetValue = Math.Min(100, issueCount * 10);

            while (progressBar.Value < targetValue)
            {
                progressBar.Value++;
                await System.Threading.Tasks.Task.Delay(8);
            }

            while (progressBar.Value > targetValue)
            {
                progressBar.Value--;
                await System.Threading.Tasks.Task.Delay(8);
            }
        }

        private void picLogo_Click(object sender, EventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
    }
}