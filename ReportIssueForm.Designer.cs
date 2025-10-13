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
        private TextBox txtLocation;
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
            this.txtLocation = new System.Windows.Forms.TextBox();
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
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.mainLayout.Controls.Add(this.lblLocation, 0, 0);
            this.mainLayout.Controls.Add(this.txtLocation, 1, 0);
            this.mainLayout.Controls.Add(this.lblCategory, 0, 1);
            this.mainLayout.Controls.Add(this.cmbCategory, 1, 1);
            this.mainLayout.Controls.Add(this.lblDescription, 0, 2);
            this.mainLayout.Controls.Add(this.rtbDescription, 1, 2);
            this.mainLayout.Controls.Add(this.lblAttachments, 0, 3);
            this.mainLayout.Controls.Add(this.lstAttachments, 1, 3);
            this.mainLayout.Controls.Add(this.btnAddAttachment, 1, 4);
            this.mainLayout.Controls.Add(this.btnSubmit, 0, 5);
            this.mainLayout.Controls.Add(this.btnBackToMenu, 1, 5);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 160);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(20);
            this.mainLayout.RowCount = 6;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.Size = new System.Drawing.Size(784, 371);
            this.mainLayout.TabIndex = 0;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLocation.Location = new System.Drawing.Point(23, 20);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(99, 20);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "📍 Location:";
            // 
            // txtLocation
            // 
            this.txtLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtLocation.Location = new System.Drawing.Point(246, 23);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(515, 27);
            this.txtLocation.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(23, 53);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(103, 20);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "📂 Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbCategory.Location = new System.Drawing.Point(246, 56);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(515, 28);
            this.cmbCategory.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(23, 80);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(119, 20);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "📝 Description:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDescription.Location = new System.Drawing.Point(246, 83);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(515, 120);
            this.rtbDescription.TabIndex = 5;
            this.rtbDescription.Text = "";
            // 
            // lblAttachments
            // 
            this.lblAttachments.AutoSize = true;
            this.lblAttachments.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAttachments.Location = new System.Drawing.Point(23, 206);
            this.lblAttachments.Name = "lblAttachments";
            this.lblAttachments.Size = new System.Drawing.Size(130, 20);
            this.lblAttachments.TabIndex = 6;
            this.lblAttachments.Text = "📎 Attachments:";
            // 
            // lstAttachments
            // 
            this.lstAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAttachments.Location = new System.Drawing.Point(246, 209);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(515, 80);
            this.lstAttachments.TabIndex = 7;
            // 
            // btnAddAttachment
            // 
            this.btnAddAttachment.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddAttachment.Location = new System.Drawing.Point(686, 295);
            this.btnAddAttachment.Name = "btnAddAttachment";
            this.btnAddAttachment.Size = new System.Drawing.Size(75, 23);
            this.btnAddAttachment.TabIndex = 8;
            this.btnAddAttachment.Text = "➕ Add Attachment";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubmit.Location = new System.Drawing.Point(56, 324);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(150, 35);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "✅ Submit Issue";
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBackToMenu.Location = new System.Drawing.Point(428, 324);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Size = new System.Drawing.Size(150, 35);
            this.btnBackToMenu.TabIndex = 10;
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
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "ReportIssueForm";
            this.Text = "Report Issue - Municipal Services";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
