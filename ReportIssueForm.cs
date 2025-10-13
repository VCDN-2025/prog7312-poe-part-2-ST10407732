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

            // Title with emoji
            lblTitle.Text = "📢 Report an Issue";
            lblTitle.ForeColor = PrimaryTeal;
            lblTitle.Height = 60;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Layout rows
            mainLayout.RowStyles.Clear();
            for (int i = 0; i < 6; i++)
                mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Location
            lblLocation.Text = "📍 Location:";
            lblLocation.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLocation.ForeColor = DarkGray;
            txtLocation.Font = new Font("Segoe UI", 11F);

            // Category
            lblCategory.Text = "📂 Category:";
            lblCategory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCategory.ForeColor = DarkGray;
            cmbCategory.Font = new Font("Segoe UI", 11F);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
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
            lblDescription.Text = "📝 Description:";
            lblDescription.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDescription.ForeColor = DarkGray;
            rtbDescription.Height = 120;

            // Attachments
            lblAttachments.Text = "📎 Attachments:";
            lblAttachments.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAttachments.ForeColor = DarkGray;
            lstAttachments.Height = 80;
            btnAddAttachment.Text = "➕ Add Attachment";
            btnAddAttachment.BackColor = AccentBlue;
            btnAddAttachment.ForeColor = Color.White;
            btnAddAttachment.FlatStyle = FlatStyle.Flat;
            btnAddAttachment.Click += btnAddAttachment_Click;

            // Submit
            btnSubmit.Text = "✅ Submit Issue";
            btnSubmit.BackColor = SuccessGreen;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Click += btnSubmit_Click;

            // Back
            btnBackToMenu.Text = "⬅ Back to Menu";
            btnBackToMenu.BackColor = PrimaryTeal;
            btnBackToMenu.ForeColor = Color.White;
            btnBackToMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBackToMenu.FlatStyle = FlatStyle.Flat;
            btnBackToMenu.Click += btnBackToMenu_Click;

            // Engagement
            lblEngagement.Text = "Community engagement tracker...";
            lblEngagement.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblEngagement.ForeColor = DarkGray;
            lblEngagement.TextAlign = ContentAlignment.MiddleCenter;

            // ProgressBar
            progressBar.Height = 20;

            // Side panel
            sidePanel.Dock = DockStyle.Right;
            sidePanel.Width = 200;
            sidePanel.BackColor = SecondaryTeal;

            Button btnMyReports = new Button
            {
                Text = "📊 My Reports",
                Dock = DockStyle.Top,
                Height = 50,
                FlatStyle = FlatStyle.Flat
            };
            btnMyReports.Click += btnMyReports_Click;

            Button btnHelp = new Button
            {
                Text = "❓ Help",
                Dock = DockStyle.Top,
                Height = 50,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = PrimaryTeal
            };
            btnHelp.Click += btnHelp_Click;

            sidePanel.Controls.Add(btnHelp);
            sidePanel.Controls.Add(btnMyReports);

            // Add controls to layout
            mainLayout.Controls.Add(lblLocation, 0, 0);
            mainLayout.Controls.Add(txtLocation, 1, 0);
            mainLayout.Controls.Add(lblCategory, 0, 1);
            mainLayout.Controls.Add(cmbCategory, 1, 1);
            mainLayout.Controls.Add(lblDescription, 0, 2);
            mainLayout.Controls.Add(rtbDescription, 1, 2);
            mainLayout.Controls.Add(lblAttachments, 0, 3);
            mainLayout.Controls.Add(lstAttachments, 1, 3);
            mainLayout.Controls.Add(btnAddAttachment, 1, 4);
            mainLayout.Controls.Add(btnSubmit, 0, 5);
            mainLayout.Controls.Add(btnBackToMenu, 1, 5);

            // Load issues
            issueList = IssueStorage.Load();
            UpdateEngagementDisplay();

            // Load logo at runtime
            string logoPath = @"C:\Users\davyc\source\repos\MunicipalServicesApp\MunicipalityLogo.png";
            if (System.IO.File.Exists(logoPath))
                picLogo.Image = Image.FromFile(logoPath);
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
            if (string.IsNullOrWhiteSpace(txtLocation.Text) || string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("⚠️ Please provide both a location and description.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            var issue = new Issue
            {
                Location = txtLocation.Text.Trim(),
                Category = cmbCategory.SelectedItem.ToString(),
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

            txtLocation.Clear();
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
                "1. Enter the exact location of the issue.\n" +
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

        private void picLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
