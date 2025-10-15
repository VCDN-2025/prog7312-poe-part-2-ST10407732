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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblProvince = new System.Windows.Forms.Label();
            this.cmbProvince = new System.Windows.Forms.ComboBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lblAttachments = new System.Windows.Forms.Label();
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.btnAddAttachment = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBackToMenu = new System.Windows.Forms.Button();
            this.lblEngagement = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.sidePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(984, 100);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 100);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(984, 60);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "📢 Report an Issue";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
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
            this.mainLayout.Controls.Add(this.btnAddAttachment, 1, 7);
            this.mainLayout.Controls.Add(this.btnSubmit, 0, 8);
            this.mainLayout.Controls.Add(this.btnBackToMenu, 1, 8);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 160);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(20);
            this.mainLayout.RowCount = 9;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.Size = new System.Drawing.Size(784, 371);
            this.mainLayout.TabIndex = 0;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.mainLayout.SetColumnSpan(this.lblLocation, 2);
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLocation.Location = new System.Drawing.Point(23, 20);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblLocation.Size = new System.Drawing.Size(99, 25);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "📍 Location:";
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProvince.Location = new System.Drawing.Point(23, 45);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.lblProvince.Size = new System.Drawing.Size(85, 24);
            this.lblProvince.TabIndex = 1;
            this.lblProvince.Text = "Province:";
            // 
            // cmbProvince
            // 
            this.cmbProvince.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvince.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbProvince.Location = new System.Drawing.Point(246, 48);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(515, 28);
            this.cmbProvince.TabIndex = 2;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCity.Location = new System.Drawing.Point(23, 79);
            this.lblCity.Name = "lblCity";
            this.lblCity.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.lblCity.Size = new System.Drawing.Size(52, 24);
            this.lblCity.TabIndex = 3;
            this.lblCity.Text = "City:";
            // 
            // cmbCity
            // 
            this.cmbCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbCity.Location = new System.Drawing.Point(246, 82);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(515, 28);
            this.cmbCity.TabIndex = 4;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArea.Location = new System.Drawing.Point(23, 113);
            this.lblArea.Name = "lblArea";
            this.lblArea.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.lblArea.Size = new System.Drawing.Size(56, 24);
            this.lblArea.TabIndex = 5;
            this.lblArea.Text = "Area:";
            // 
            // cmbArea
            // 
            this.cmbArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbArea.Location = new System.Drawing.Point(246, 116);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(515, 28);
            this.cmbArea.TabIndex = 6;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(23, 147);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblCategory.Size = new System.Drawing.Size(103, 30);
            this.lblCategory.TabIndex = 7;
            this.lblCategory.Text = "📂 Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbCategory.Location = new System.Drawing.Point(246, 160);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(515, 28);
            this.cmbCategory.TabIndex = 8;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(23, 191);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblDescription.Size = new System.Drawing.Size(119, 30);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "📝 Description:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDescription.Location = new System.Drawing.Point(246, 204);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(515, 120);
            this.rtbDescription.TabIndex = 10;
            this.rtbDescription.Text = "";
            // 
            // lblAttachments
            // 
            this.lblAttachments.AutoSize = true;
            this.lblAttachments.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAttachments.Location = new System.Drawing.Point(23, 327);
            this.lblAttachments.Name = "lblAttachments";
            this.lblAttachments.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblAttachments.Size = new System.Drawing.Size(130, 30);
            this.lblAttachments.TabIndex = 11;
            this.lblAttachments.Text = "📎 Attachments:";
            // 
            // lstAttachments
            // 
            this.lstAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAttachments.Location = new System.Drawing.Point(246, 340);
            this.lstAttachments.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(515, 80);
            this.lstAttachments.TabIndex = 12;
            // 
            // btnAddAttachment
            // 
            this.btnAddAttachment.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddAttachment.Location = new System.Drawing.Point(601, 426);
            this.btnAddAttachment.Name = "btnAddAttachment";
            this.btnAddAttachment.Size = new System.Drawing.Size(160, 35);
            this.btnAddAttachment.TabIndex = 13;
            this.btnAddAttachment.Text = "➕ Add Attachment";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubmit.Location = new System.Drawing.Point(56, 474);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(150, 40);
            this.btnSubmit.TabIndex = 14;
            this.btnSubmit.Text = "✅ Submit Issue";
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBackToMenu.Location = new System.Drawing.Point(428, 474);
            this.btnBackToMenu.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Size = new System.Drawing.Size(150, 40);
            this.btnBackToMenu.TabIndex = 15;
            this.btnBackToMenu.Text = "⬅ Back to Menu";
            // 
            // lblEngagement
            // 
            this.lblEngagement.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEngagement.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblEngagement.Location = new System.Drawing.Point(0, 551);
            this.lblEngagement.Name = "lblEngagement";
            this.lblEngagement.Size = new System.Drawing.Size(984, 30);
            this.lblEngagement.TabIndex = 5;
            this.lblEngagement.Text = "Community engagement tracker...";
            this.lblEngagement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 531);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(984, 20);
            this.progressBar.TabIndex = 4;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.LightGray;
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.sidePanel.Location = new System.Drawing.Point(784, 160);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(200, 371);
            this.sidePanel.TabIndex = 1;
            // 
            // ReportIssueForm
            // 
            this.ClientSize = new System.Drawing.Size(984, 581);
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblEngagement);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ReportIssueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Issue - Municipal Services";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}