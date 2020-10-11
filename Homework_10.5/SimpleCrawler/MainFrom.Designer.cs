namespace SimpleCrawler
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtStartUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crawlButton = new System.Windows.Forms.Button();
            this.urlListBox = new System.Windows.Forms.ListBox();
            this.messageListBox = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtStartUrl);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.crawlButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(998, 50);
            this.panel2.TabIndex = 2;
            // 
            // txtStartUrl
            // 
            this.txtStartUrl.Location = new System.Drawing.Point(91, 12);
            this.txtStartUrl.Name = "txtStartUrl";
            this.txtStartUrl.Size = new System.Drawing.Size(539, 28);
            this.txtStartUrl.TabIndex = 2;
            this.txtStartUrl.Text = "https://www.cnblogs.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "起始网页";
            // 
            // crawlButton
            // 
            this.crawlButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crawlButton.Location = new System.Drawing.Point(909, 8);
            this.crawlButton.Name = "crawlButton";
            this.crawlButton.Size = new System.Drawing.Size(75, 35);
            this.crawlButton.TabIndex = 0;
            this.crawlButton.Text = "爬取";
            this.crawlButton.UseVisualStyleBackColor = true;
            this.crawlButton.Click += new System.EventHandler(this.crawlButton_Click);
            // 
            // urlListBox
            // 
            this.urlListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlListBox.FormattingEnabled = true;
            this.urlListBox.ItemHeight = 18;
            this.urlListBox.Location = new System.Drawing.Point(0, 0);
            this.urlListBox.Margin = new System.Windows.Forms.Padding(0);
            this.urlListBox.Name = "urlListBox";
            this.urlListBox.Size = new System.Drawing.Size(630, 601);
            this.urlListBox.TabIndex = 0;
            // 
            // messageListBox
            // 
            this.messageListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageListBox.FormattingEnabled = true;
            this.messageListBox.ItemHeight = 18;
            this.messageListBox.Location = new System.Drawing.Point(0, 0);
            this.messageListBox.Name = "messageListBox";
            this.messageListBox.Size = new System.Drawing.Size(364, 601);
            this.messageListBox.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.urlListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.messageListBox);
            this.splitContainer1.Size = new System.Drawing.Size(998, 601);
            this.splitContainer1.SplitterDistance = 630;
            this.splitContainer1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 651);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Name = "MainForm";
            this.Text = "Simple Crawler";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtStartUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button crawlButton;
        private System.Windows.Forms.ListBox urlListBox;
        private System.Windows.Forms.ListBox messageListBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}