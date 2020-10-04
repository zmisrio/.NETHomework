namespace CayleyTrees
{
    public partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCayleyTree = new System.Windows.Forms.Panel();
            this.btnDraw = new System.Windows.Forms.Button();
            this.cmbPenColor = new System.Windows.Forms.ComboBox();
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtLeng = new System.Windows.Forms.TextBox();
            this.txtPer1 = new System.Windows.Forms.TextBox();
            this.txtTh1 = new System.Windows.Forms.TextBox();
            this.txtTh2 = new System.Windows.Forms.TextBox();
            this.txtPenColor = new System.Windows.Forms.TextBox();
            this.txtPer2 = new System.Windows.Forms.TextBox();
            this.hscPer1 = new System.Windows.Forms.HScrollBar();
            this.hscPer2 = new System.Windows.Forms.HScrollBar();
            this.hscTh1 = new System.Windows.Forms.HScrollBar();
            this.hscTh2 = new System.Windows.Forms.HScrollBar();
            this.hscN = new System.Windows.Forms.HScrollBar();
            this.hscLeng = new System.Windows.Forms.HScrollBar();
            this.lblN = new System.Windows.Forms.Label();
            this.lblLeng = new System.Windows.Forms.Label();
            this.lblPer1 = new System.Windows.Forms.Label();
            this.lblPer2 = new System.Windows.Forms.Label();
            this.lblTh1 = new System.Windows.Forms.Label();
            this.lblTh2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlCayleyTree
            // 
            this.pnlCayleyTree.BackColor = System.Drawing.Color.LightYellow;
            this.pnlCayleyTree.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCayleyTree.Location = new System.Drawing.Point(411, 0);
            this.pnlCayleyTree.Name = "pnlCayleyTree";
            this.pnlCayleyTree.Size = new System.Drawing.Size(617, 542);
            this.pnlCayleyTree.TabIndex = 0;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(74, 455);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(257, 48);
            this.btnDraw.TabIndex = 13;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // cmbPenColor
            // 
            this.cmbPenColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPenColor.FormattingEnabled = true;
            this.cmbPenColor.Location = new System.Drawing.Point(160, 390);
            this.cmbPenColor.Name = "cmbPenColor";
            this.cmbPenColor.Size = new System.Drawing.Size(216, 26);
            this.cmbPenColor.TabIndex = 14;
            this.cmbPenColor.SelectedIndexChanged += new System.EventHandler(this.cmbPenColor_SelectedIndexChanged);
            // 
            // txtN
            // 
            this.txtN.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtN.Location = new System.Drawing.Point(35, 35);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(100, 21);
            this.txtN.TabIndex = 15;
            this.txtN.Text = "迭代次数";
            this.txtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLeng
            // 
            this.txtLeng.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtLeng.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLeng.Location = new System.Drawing.Point(35, 95);
            this.txtLeng.Name = "txtLeng";
            this.txtLeng.Size = new System.Drawing.Size(100, 21);
            this.txtLeng.TabIndex = 16;
            this.txtLeng.Text = "主干长度";
            this.txtLeng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPer1
            // 
            this.txtPer1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtPer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPer1.Location = new System.Drawing.Point(24, 155);
            this.txtPer1.Name = "txtPer1";
            this.txtPer1.Size = new System.Drawing.Size(120, 21);
            this.txtPer1.TabIndex = 17;
            this.txtPer1.Text = "右分支长度比";
            this.txtPer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTh1
            // 
            this.txtTh1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtTh1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTh1.Location = new System.Drawing.Point(35, 275);
            this.txtTh1.Name = "txtTh1";
            this.txtTh1.Size = new System.Drawing.Size(100, 21);
            this.txtTh1.TabIndex = 19;
            this.txtTh1.Text = "右分支角度";
            this.txtTh1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTh2
            // 
            this.txtTh2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtTh2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTh2.Location = new System.Drawing.Point(35, 335);
            this.txtTh2.Name = "txtTh2";
            this.txtTh2.Size = new System.Drawing.Size(100, 21);
            this.txtTh2.TabIndex = 20;
            this.txtTh2.Text = "左分支角度";
            this.txtTh2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPenColor
            // 
            this.txtPenColor.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtPenColor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPenColor.Location = new System.Drawing.Point(35, 395);
            this.txtPenColor.Name = "txtPenColor";
            this.txtPenColor.Size = new System.Drawing.Size(100, 21);
            this.txtPenColor.TabIndex = 21;
            this.txtPenColor.Text = "画笔颜色";
            this.txtPenColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPer2
            // 
            this.txtPer2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtPer2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPer2.Location = new System.Drawing.Point(24, 215);
            this.txtPer2.Name = "txtPer2";
            this.txtPer2.Size = new System.Drawing.Size(120, 21);
            this.txtPer2.TabIndex = 22;
            this.txtPer2.Text = "左分支长度比";
            this.txtPer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hscPer1
            // 
            this.hscPer1.Location = new System.Drawing.Point(160, 150);
            this.hscPer1.Maximum = 109;
            this.hscPer1.Name = "hscPer1";
            this.hscPer1.Size = new System.Drawing.Size(170, 26);
            this.hscPer1.TabIndex = 23;
            this.hscPer1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscPer1_Scroll);
            // 
            // hscPer2
            // 
            this.hscPer2.Location = new System.Drawing.Point(160, 210);
            this.hscPer2.Maximum = 109;
            this.hscPer2.Name = "hscPer2";
            this.hscPer2.Size = new System.Drawing.Size(170, 26);
            this.hscPer2.TabIndex = 24;
            this.hscPer2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscPer2_Scroll);
            // 
            // hscTh1
            // 
            this.hscTh1.Location = new System.Drawing.Point(160, 270);
            this.hscTh1.Maximum = 99;
            this.hscTh1.Name = "hscTh1";
            this.hscTh1.Size = new System.Drawing.Size(170, 26);
            this.hscTh1.TabIndex = 25;
            this.hscTh1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscTh1_Scroll);
            // 
            // hscTh2
            // 
            this.hscTh2.Location = new System.Drawing.Point(160, 330);
            this.hscTh2.Maximum = 99;
            this.hscTh2.Name = "hscTh2";
            this.hscTh2.Size = new System.Drawing.Size(170, 26);
            this.hscTh2.TabIndex = 26;
            this.hscTh2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscTh2_Scroll);
            // 
            // hscN
            // 
            this.hscN.Location = new System.Drawing.Point(160, 30);
            this.hscN.Maximum = 24;
            this.hscN.Minimum = 3;
            this.hscN.Name = "hscN";
            this.hscN.Size = new System.Drawing.Size(170, 26);
            this.hscN.TabIndex = 27;
            this.hscN.Value = 3;
            this.hscN.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscN_Scroll);
            // 
            // hscLeng
            // 
            this.hscLeng.Location = new System.Drawing.Point(160, 90);
            this.hscLeng.Maximum = 159;
            this.hscLeng.Minimum = 50;
            this.hscLeng.Name = "hscLeng";
            this.hscLeng.Size = new System.Drawing.Size(170, 26);
            this.hscLeng.TabIndex = 28;
            this.hscLeng.Value = 50;
            this.hscLeng.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscLeng_Scroll);
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(350, 35);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(35, 18);
            this.lblN.TabIndex = 29;
            this.lblN.Text = "3次";
            // 
            // lblLeng
            // 
            this.lblLeng.AutoSize = true;
            this.lblLeng.Location = new System.Drawing.Point(350, 95);
            this.lblLeng.Name = "lblLeng";
            this.lblLeng.Size = new System.Drawing.Size(26, 18);
            this.lblLeng.TabIndex = 0;
            this.lblLeng.Text = "10";
            // 
            // lblPer1
            // 
            this.lblPer1.AutoSize = true;
            this.lblPer1.Location = new System.Drawing.Point(350, 155);
            this.lblPer1.Name = "lblPer1";
            this.lblPer1.Size = new System.Drawing.Size(35, 18);
            this.lblPer1.TabIndex = 30;
            this.lblPer1.Text = "60%";
            // 
            // lblPer2
            // 
            this.lblPer2.AutoSize = true;
            this.lblPer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPer2.Location = new System.Drawing.Point(350, 215);
            this.lblPer2.Name = "lblPer2";
            this.lblPer2.Size = new System.Drawing.Size(35, 18);
            this.lblPer2.TabIndex = 31;
            this.lblPer2.Text = "70%";
            // 
            // lblTh1
            // 
            this.lblTh1.AutoSize = true;
            this.lblTh1.Location = new System.Drawing.Point(350, 275);
            this.lblTh1.Name = "lblTh1";
            this.lblTh1.Size = new System.Drawing.Size(44, 18);
            this.lblTh1.TabIndex = 32;
            this.lblTh1.Text = "30°";
            // 
            // lblTh2
            // 
            this.lblTh2.AutoSize = true;
            this.lblTh2.Location = new System.Drawing.Point(350, 335);
            this.lblTh2.Name = "lblTh2";
            this.lblTh2.Size = new System.Drawing.Size(44, 18);
            this.lblTh2.TabIndex = 33;
            this.lblTh2.Text = "30°";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 542);
            this.Controls.Add(this.lblTh2);
            this.Controls.Add(this.lblTh1);
            this.Controls.Add(this.lblPer2);
            this.Controls.Add(this.lblPer1);
            this.Controls.Add(this.lblLeng);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.hscLeng);
            this.Controls.Add(this.hscN);
            this.Controls.Add(this.hscTh2);
            this.Controls.Add(this.hscTh1);
            this.Controls.Add(this.hscPer2);
            this.Controls.Add(this.hscPer1);
            this.Controls.Add(this.txtPer2);
            this.Controls.Add(this.txtPenColor);
            this.Controls.Add(this.txtTh2);
            this.Controls.Add(this.txtTh1);
            this.Controls.Add(this.txtPer1);
            this.Controls.Add(this.txtLeng);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.cmbPenColor);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.pnlCayleyTree);
            this.Name = "Form1";
            this.Text = "CayleyTree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCayleyTree;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.ComboBox cmbPenColor;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.TextBox txtLeng;
        private System.Windows.Forms.TextBox txtPer1;
        private System.Windows.Forms.TextBox txtTh1;
        private System.Windows.Forms.TextBox txtTh2;
        private System.Windows.Forms.TextBox txtPenColor;
        private System.Windows.Forms.TextBox txtPer2;
        private System.Windows.Forms.HScrollBar hscPer1;
        private System.Windows.Forms.HScrollBar hscPer2;
        private System.Windows.Forms.HScrollBar hscTh1;
        private System.Windows.Forms.HScrollBar hscTh2;
        private System.Windows.Forms.HScrollBar hscN;
        private System.Windows.Forms.HScrollBar hscLeng;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.Label lblLeng;
        private System.Windows.Forms.Label lblPer1;
        private System.Windows.Forms.Label lblPer2;
        private System.Windows.Forms.Label lblTh1;
        private System.Windows.Forms.Label lblTh2;
    }
}

