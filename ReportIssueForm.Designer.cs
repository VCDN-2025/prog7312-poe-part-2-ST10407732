using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    partial class ReportIssueForm
    {
        private System.ComponentModel.IContainer components = null;

        private PictureBox picLogo;
        private Label lblTitle;
        private Label lblLocation;
        private Label lblProvince;
        private ComboBox cmbProvince;
        private Label lblCity;
        private ComboBox cmbCity;
        private Label lblArea;
        private ComboBox cmbArea;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblDescription;
        private RichTextBox rtbDescription;
        private Label lblAttachments;
        private ListBox lstAttachments;
        private Button btnAddAttachment;
        private Button btnSubmit;
        private Button btnBackToMenu;
        private Label lblEngagement;
        private ProgressBar progressBar;
        private TableLayoutPanel mainLayout;
        private Panel sidePanel;
        private Panel scrollablePanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picLogo = new PictureBox();
            this.lblTitle = new Label();
            this.scrollablePanel = new Panel();
            this.mainLayout = new TableLayoutPanel();
            this.lblLocation = new Label();
            this.lblProvince = new Label();
            this.cmbProvince = new ComboBox();
            this.lblCity = new Label();
            this.cmbCity = new ComboBox();
            this.lblArea = new Label();
            this.cmbArea = new ComboBox();
            this.lblCategory = new Label();
            this.cmbCategory = new ComboBox();
            this.lblDescription = new Label();
            this.rtbDescription = new RichTextBox();
            this.lblAttachments = new Label();
            this.lstAttachments = new ListBox();
            this.btnAddAttachment = new Button();
            this.btnSubmit = new Button();
            this.btnBackToMenu = new Button();
            this.lblEngagement = new Label();
            this.progressBar = new ProgressBar();
            this.sidePanel = new Panel();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.scrollablePanel.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();

            // 🔹 Back to Menu Button (Top-Left Corner)
            this.btnBackToMenu.Text = "⬅ Back to Menu";
            this.btnBackToMenu.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.btnBackToMenu.Size = new Size(140, 38);
            this.btnBackToMenu.Location = new Point(15, 15);
            this.btnBackToMenu.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnBackToMenu.BackColor = Color.FromArgb(240, 240, 240);

            // 🔹 Logo
            this.picLogo.Dock = DockStyle.Top;
            this.picLogo.Size = new Size(984, 100);
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.picLogo.BackColor = Color.White;

            // 🔹 Title
            this.lblTitle.Dock = DockStyle.Top;
            this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "📢 Report an Issue";
            this.lblTitle.Height = 60;

            // 🔹 Scrollable Panel
            this.scrollablePanel.Dock = DockStyle.Fill;
            this.scrollablePanel.AutoScroll = true;
            this.scrollablePanel.Controls.Add(this.mainLayout);
            this.scrollablePanel.Controls.Add(this.sidePanel);

            // 🔹 Main Layout
            this.mainLayout.AutoSize = true;
            this.mainLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.Padding = new Padding(20, 20, 20, 20);
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 580F));

            // 🔹 Rows
            this.mainLayout.RowCount = 8;
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // 🔹 Add controls to layout
            this.mainLayout.Controls.Add(this.lblLocation, 0, 0);
            this.mainLayout.Controls.Add(this.lblProvince, 0, 1);
            this.mainLayout.Controls.Add(this.cmbProvince, 1, 1);
            this.mainLayout.Controls.Add(this.lblCity, 0, 2);
            this.mainLayout.Controls.Add(this.cmbCity, 1, 2);
            this.mainLayout.Controls.Add(this.lblArea, 0, 3);
            this.mainLayout.Controls.Add(this.cmbArea, 1, 3);
            this.mainLayout.Controls.Add(this.lblCategory, 0, 4);
            this.mainLayout.Controls.Add(this.cmbCategory, 1, 4);
            this.mainLayout.Controls.Add(this.lblDescription, 0, 5);
            this.mainLayout.Controls.Add(this.rtbDescription, 1, 5);
            this.mainLayout.Controls.Add(this.lblAttachments, 0, 6);
            this.mainLayout.Controls.Add(this.lstAttachments, 1, 6);

            // 🔹 Button panel (bottom)
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Padding = new Padding(0),
                Margin = new Padding(0, 15, 0, 0),
                Anchor = AnchorStyles.None,
                WrapContents = false
            };

            // 🔹 Buttons (bottom)
            this.btnAddAttachment.Size = new Size(160, 44);
            this.btnAddAttachment.Text = "➕ Add Attachment";

            this.btnSubmit.Size = new Size(150, 44);
            this.btnSubmit.Text = "✅ Submit Issue";

            buttonPanel.Controls.Add(this.btnAddAttachment);
            buttonPanel.Controls.Add(this.btnSubmit);

            this.mainLayout.Controls.Add(buttonPanel, 0, 7);
            this.mainLayout.SetColumnSpan(buttonPanel, 2);

            // 🔹 Labels & Fields
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblLocation.Text = "📍 Location:";

            this.lblProvince.Text = "Province:";
            this.cmbProvince.Font = new Font("Segoe UI", 11F);
            this.cmbProvince.DropDownStyle = ComboBoxStyle.DropDownList;

            this.lblCity.Text = "City:";
            this.cmbCity.Font = new Font("Segoe UI", 11F);
            this.cmbCity.DropDownStyle = ComboBoxStyle.DropDownList;

            this.lblArea.Text = "Area:";
            this.cmbArea.Font = new Font("Segoe UI", 11F);

            this.lblCategory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblCategory.Text = "📂 Category:";
            this.cmbCategory.Font = new Font("Segoe UI", 11F);
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            this.lblDescription.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDescription.Text = "📝 Description:";
            this.rtbDescription.Font = new Font("Segoe UI", 10F);

            this.lblAttachments.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblAttachments.Text = "📎 Attachments:";
            this.lstAttachments.Height = 80;

            // 🔹 Side Panel
            this.sidePanel.BackColor = Color.LightGray;
            this.sidePanel.Dock = DockStyle.Right;
            this.sidePanel.Width = 200;

            // 🔹 Footer
            this.lblEngagement.Dock = DockStyle.Bottom;
            this.lblEngagement.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblEngagement.Text = "Community engagement tracker...";
            this.lblEngagement.TextAlign = ContentAlignment.MiddleCenter;

            this.progressBar.Dock = DockStyle.Bottom;

            // 🔹 Form
            this.ClientSize = new Size(984, 581);
            this.Controls.Add(this.scrollablePanel);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnBackToMenu); // stays above all
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblEngagement);
            this.MinimumSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Report Issue - Municipal Services";

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.scrollablePanel.ResumeLayout(false);
            this.scrollablePanel.PerformLayout();
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
