using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // placeholders + core controls
        private TableLayoutPanel layoutPanel;
        private Panel headerPlaceholder;
        private Panel progressPlaceholder;
        private Panel cardsPlaceholder;
        private Panel statsPlaceholder;
        private Panel footerPlaceholder;
        private PictureBox picLogo;
        private ProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerPlaceholder = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.progressPlaceholder = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.cardsPlaceholder = new System.Windows.Forms.Panel();
            this.statsPlaceholder = new System.Windows.Forms.Panel();
            this.footerPlaceholder = new System.Windows.Forms.Panel();
            this.layoutPanel.SuspendLayout();
            this.headerPlaceholder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.progressPlaceholder.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutPanel
            // 
            this.layoutPanel.ColumnCount = 1;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.Controls.Add(this.headerPlaceholder, 0, 0);
            this.layoutPanel.Controls.Add(this.progressPlaceholder, 0, 1);
            this.layoutPanel.Controls.Add(this.cardsPlaceholder, 0, 2);
            this.layoutPanel.Controls.Add(this.statsPlaceholder, 0, 3);
            this.layoutPanel.Controls.Add(this.footerPlaceholder, 0, 4);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 5;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.layoutPanel.Size = new System.Drawing.Size(1000, 749);
            this.layoutPanel.TabIndex = 0;
            // 
            // headerPlaceholder
            // 
            this.headerPlaceholder.Controls.Add(this.picLogo);
            this.headerPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPlaceholder.Location = new System.Drawing.Point(0, 0);
            this.headerPlaceholder.Margin = new System.Windows.Forms.Padding(0);
            this.headerPlaceholder.Name = "headerPlaceholder";
            this.headerPlaceholder.Size = new System.Drawing.Size(1000, 140);
            this.headerPlaceholder.TabIndex = 0;
            this.headerPlaceholder.Paint += new System.Windows.Forms.PaintEventHandler(this.headerPlaceholder_Paint);
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 140);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // progressPlaceholder
            // 
            this.progressPlaceholder.Controls.Add(this.progressBar);
            this.progressPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPlaceholder.Location = new System.Drawing.Point(0, 140);
            this.progressPlaceholder.Margin = new System.Windows.Forms.Padding(0);
            this.progressPlaceholder.Name = "progressPlaceholder";
            this.progressPlaceholder.Size = new System.Drawing.Size(1000, 60);
            this.progressPlaceholder.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1000, 60);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // cardsPlaceholder
            // 
            this.cardsPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardsPlaceholder.Location = new System.Drawing.Point(3, 203);
            this.cardsPlaceholder.Name = "cardsPlaceholder";
            this.cardsPlaceholder.Size = new System.Drawing.Size(994, 233);
            this.cardsPlaceholder.TabIndex = 2;
            // 
            // statsPlaceholder
            // 
            this.statsPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsPlaceholder.Location = new System.Drawing.Point(3, 442);
            this.statsPlaceholder.Name = "statsPlaceholder";
            this.statsPlaceholder.Size = new System.Drawing.Size(994, 233);
            this.statsPlaceholder.TabIndex = 3;
            // 
            // footerPlaceholder
            // 
            this.footerPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footerPlaceholder.Location = new System.Drawing.Point(3, 681);
            this.footerPlaceholder.Name = "footerPlaceholder";
            this.footerPlaceholder.Size = new System.Drawing.Size(994, 65);
            this.footerPlaceholder.TabIndex = 4;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 749);
            this.Controls.Add(this.layoutPanel);
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services Portal";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.layoutPanel.ResumeLayout(false);
            this.headerPlaceholder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.progressPlaceholder.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
