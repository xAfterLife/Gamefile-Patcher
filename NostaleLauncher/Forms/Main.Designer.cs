
namespace NostaleLauncher.Forms
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlWebBrowser = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbNews = new System.Windows.Forms.RichTextBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnDiscord = new System.Windows.Forms.Button();
            this.linkEvent = new System.Windows.Forms.LinkLabel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnGuide = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.cmbAccounts = new System.Windows.Forms.ComboBox();
            this.pnlWebBrowser.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbProgress
            // 
            this.pbProgress.ForeColor = System.Drawing.Color.Cyan;
            this.pbProgress.Location = new System.Drawing.Point(91, 619);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(1050, 31);
            this.pbProgress.Step = 1;
            this.pbProgress.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(31, 619);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(36, 31);
            this.btnStart.TabIndex = 1;
            this.btnStart.TabStop = false;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // pnlWebBrowser
            // 
            this.pnlWebBrowser.BackColor = System.Drawing.Color.Transparent;
            this.pnlWebBrowser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlWebBrowser.Controls.Add(this.label1);
            this.pnlWebBrowser.Controls.Add(this.rtbNews);
            this.pnlWebBrowser.Location = new System.Drawing.Point(91, 60);
            this.pnlWebBrowser.Name = "pnlWebBrowser";
            this.pnlWebBrowser.Size = new System.Drawing.Size(1050, 480);
            this.pnlWebBrowser.TabIndex = 2;
            this.pnlWebBrowser.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.MaximumSize = new System.Drawing.Size(1050, 480);
            this.label1.MinimumSize = new System.Drawing.Size(1050, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1050, 480);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // rtbNews
            // 
            this.rtbNews.BackColor = System.Drawing.Color.LavenderBlush;
            this.rtbNews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNews.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtbNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbNews.Enabled = false;
            this.rtbNews.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rtbNews.Location = new System.Drawing.Point(0, 0);
            this.rtbNews.Name = "rtbNews";
            this.rtbNews.ReadOnly = true;
            this.rtbNews.Size = new System.Drawing.Size(1050, 480);
            this.rtbNews.TabIndex = 0;
            this.rtbNews.TabStop = false;
            this.rtbNews.Text = "";
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BackgroundImage = global::NostaleLauncher.RES.gears;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(1163, 619);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(42, 31);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.TabStop = false;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnDiscord
            // 
            this.btnDiscord.BackColor = System.Drawing.Color.Transparent;
            this.btnDiscord.BackgroundImage = global::NostaleLauncher.RES.discord;
            this.btnDiscord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDiscord.FlatAppearance.BorderSize = 0;
            this.btnDiscord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDiscord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDiscord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscord.Location = new System.Drawing.Point(1163, 275);
            this.btnDiscord.Name = "btnDiscord";
            this.btnDiscord.Size = new System.Drawing.Size(42, 42);
            this.btnDiscord.TabIndex = 4;
            this.btnDiscord.TabStop = false;
            this.btnDiscord.UseVisualStyleBackColor = false;
            this.btnDiscord.Click += new System.EventHandler(this.BtnDiscord_Click);
            // 
            // linkEvent
            // 
            this.linkEvent.AutoSize = true;
            this.linkEvent.BackColor = System.Drawing.Color.Black;
            this.linkEvent.LinkColor = System.Drawing.Color.Indigo;
            this.linkEvent.Location = new System.Drawing.Point(882, 543);
            this.linkEvent.Name = "linkEvent";
            this.linkEvent.Size = new System.Drawing.Size(259, 17);
            this.linkEvent.TabIndex = 5;
            this.linkEvent.TabStop = true;
            this.linkEvent.Text = "The <Placeholder> Event is currently Active";
            this.linkEvent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Black;
            this.lblStatus.ForeColor = System.Drawing.Color.Violet;
            this.lblStatus.Location = new System.Drawing.Point(91, 599);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(205, 17);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "<Placeholder Status of Launcher>";
            // 
            // btnGuide
            // 
            this.btnGuide.BackColor = System.Drawing.Color.Transparent;
            this.btnGuide.BackgroundImage = global::NostaleLauncher.RES.guide;
            this.btnGuide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuide.FlatAppearance.BorderSize = 0;
            this.btnGuide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGuide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGuide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuide.Location = new System.Drawing.Point(1159, 490);
            this.btnGuide.Name = "btnGuide";
            this.btnGuide.Size = new System.Drawing.Size(50, 50);
            this.btnGuide.TabIndex = 7;
            this.btnGuide.TabStop = false;
            this.btnGuide.UseVisualStyleBackColor = false;
            this.btnGuide.Click += new System.EventHandler(this.BtnGuide_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(1067, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Created by AfterLife#8695";
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BackgroundImage = global::NostaleLauncher.RES.home;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Location = new System.Drawing.Point(1163, 60);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(42, 42);
            this.btnHome.TabIndex = 9;
            this.btnHome.TabStop = false;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnAccounts
            // 
            this.btnAccounts.BackColor = System.Drawing.Color.Transparent;
            this.btnAccounts.BackgroundImage = global::NostaleLauncher.RES.user;
            this.btnAccounts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccounts.FlatAppearance.BorderSize = 0;
            this.btnAccounts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAccounts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccounts.Location = new System.Drawing.Point(94, 15);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(42, 42);
            this.btnAccounts.TabIndex = 11;
            this.btnAccounts.TabStop = false;
            this.btnAccounts.UseVisualStyleBackColor = false;
            this.btnAccounts.Visible = false;
            this.btnAccounts.Click += new System.EventHandler(this.btnAccounts_Click);
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccounts.FormattingEnabled = true;
            this.cmbAccounts.Location = new System.Drawing.Point(143, 25);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Size = new System.Drawing.Size(153, 25);
            this.cmbAccounts.TabIndex = 12;
            this.cmbAccounts.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::NostaleLauncher.RES.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1232, 663);
            this.Controls.Add(this.cmbAccounts);
            this.Controls.Add(this.btnAccounts);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGuide);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.linkEvent);
            this.Controls.Add(this.btnDiscord);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.pnlWebBrowser);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbProgress);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.pnlWebBrowser.ResumeLayout(false);
            this.pnlWebBrowser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnStart;

        #endregion

        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Panel pnlWebBrowser;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnDiscord;
        private System.Windows.Forms.LinkLabel linkEvent;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.RichTextBox rtbNews;
        private System.Windows.Forms.Button btnGuide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.ComboBox cmbAccounts;
    }
}

