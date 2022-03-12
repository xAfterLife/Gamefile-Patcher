
namespace AdminPanel.Forms
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.txtEventText = new System.Windows.Forms.TextBox();
            this.lblEventText = new System.Windows.Forms.Label();
            this.lblEventLink = new System.Windows.Forms.Label();
            this.txtEventLink = new System.Windows.Forms.TextBox();
            this.lblNews = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtNews = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtEventText
            // 
            this.txtEventText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEventText.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEventText.Location = new System.Drawing.Point(111, 12);
            this.txtEventText.Name = "txtEventText";
            this.txtEventText.Size = new System.Drawing.Size(677, 25);
            this.txtEventText.TabIndex = 0;
            // 
            // lblEventText
            // 
            this.lblEventText.AutoSize = true;
            this.lblEventText.BackColor = System.Drawing.Color.Transparent;
            this.lblEventText.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblEventText.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblEventText.Location = new System.Drawing.Point(12, 14);
            this.lblEventText.Name = "lblEventText";
            this.lblEventText.Size = new System.Drawing.Size(66, 17);
            this.lblEventText.TabIndex = 1;
            this.lblEventText.Text = "Event Text";
            // 
            // lblEventLink
            // 
            this.lblEventLink.AutoSize = true;
            this.lblEventLink.BackColor = System.Drawing.Color.Transparent;
            this.lblEventLink.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblEventLink.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblEventLink.Location = new System.Drawing.Point(12, 45);
            this.lblEventLink.Name = "lblEventLink";
            this.lblEventLink.Size = new System.Drawing.Size(65, 17);
            this.lblEventLink.TabIndex = 3;
            this.lblEventLink.Text = "Event Link";
            // 
            // txtEventLink
            // 
            this.txtEventLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEventLink.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEventLink.Location = new System.Drawing.Point(111, 43);
            this.txtEventLink.Name = "txtEventLink";
            this.txtEventLink.Size = new System.Drawing.Size(677, 25);
            this.txtEventLink.TabIndex = 2;
            // 
            // lblNews
            // 
            this.lblNews.AutoSize = true;
            this.lblNews.BackColor = System.Drawing.Color.Transparent;
            this.lblNews.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblNews.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblNews.Location = new System.Drawing.Point(12, 76);
            this.lblNews.Name = "lblNews";
            this.lblNews.Size = new System.Drawing.Size(40, 17);
            this.lblNews.TabIndex = 5;
            this.lblNews.Text = "News";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart.Location = new System.Drawing.Point(12, 222);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(776, 30);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Create JSON-Files";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // txtNews
            // 
            this.txtNews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNews.Location = new System.Drawing.Point(111, 76);
            this.txtNews.Name = "txtNews";
            this.txtNews.Size = new System.Drawing.Size(677, 140);
            this.txtNews.TabIndex = 7;
            this.txtNews.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::AdminPanel.Properties.Resources._61a05277c563926103b29024367a6daebfb9;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 264);
            this.Controls.Add(this.txtNews);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblNews);
            this.Controls.Add(this.lblEventLink);
            this.Controls.Add(this.txtEventLink);
            this.Controls.Add(this.lblEventText);
            this.Controls.Add(this.txtEventText);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "AdminPanel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEventText;
        private System.Windows.Forms.Label lblEventText;
        private System.Windows.Forms.Label lblEventLink;
        private System.Windows.Forms.TextBox txtEventLink;
        private System.Windows.Forms.Label lblNews;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RichTextBox txtNews;
    }
}

