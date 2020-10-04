using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTrees
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private double th1 = 30 * Math.PI / 180;        //左分支角度
        private double th2 = 30 * Math.PI / 180;        //右分支角度
        private double per1 = 0.6;                      //左分支长度比
        private double per2 = 0.7;                      //右分支长度比
        private double th = -90 * Math.PI / 180;
        Pen PenColor = Pens.Black;                      //画笔颜色
        int n = 3;                                      //递归深度
        int leng = 100;
        double x0;
        double y0;

        public Form1()
        {
            InitializeComponent();
            InitializeCMBPenColor();
            graphics = pnlCayleyTree.CreateGraphics();
            x0 = pnlCayleyTree.Width / 2;
            y0 = pnlCayleyTree.Height * 9 / 10;
        }
        private void InitializeCMBPenColor()
        {
            cmbPenColor.Items.Add(Pens.Black);
            cmbPenColor.Items.Add(Pens.SkyBlue);
            cmbPenColor.Items.Add(Pens.OrangeRed);
            cmbPenColor.Items.Add(Pens.DarkSeaGreen);

            cmbPenColor.DisplayMember = "Color";
        }

        private void DrawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0)
                return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            DrawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        private void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(PenColor, (int)x0, (int)y0, (int)x1, (int)y1);
        }


        private void btnDraw_Click(object sender, EventArgs e)
        {
            graphics.Clear(pnlCayleyTree.BackColor);
            DrawCayleyTree(n, x0, y0, leng, th);
        }

        private void hscPer1_Scroll(object sender, ScrollEventArgs e)
        {
            lblPer1.Text = hscPer1.Value + "%";
            per1 = hscPer1.Value / 100.0;
        }

        private void hscPer2_Scroll(object sender, ScrollEventArgs e)
        {
            lblPer2.Text = hscPer2.Value + "%";
            per2 = hscPer2.Value / 100.0;
        }

        private void hscTh1_Scroll(object sender, ScrollEventArgs e)
        {
            lblTh1.Text = hscTh1.Value + "°";
            th1 = hscTh1.Value * Math.PI / 180;
        }

        private void hscTh2_Scroll(object sender, ScrollEventArgs e)
        {
            lblTh2.Text = hscTh2.Value + "°";
            th2 = hscTh2.Value * Math.PI / 180;
        }

        private void hscN_Scroll(object sender, ScrollEventArgs e)
        {
            lblN.Text = hscN.Value + "次";
            n = hscN.Value;
        }

        private void hscLeng_Scroll(object sender, ScrollEventArgs e)
        {
            lblLeng.Text = hscLeng.Value.ToString();
            leng = hscLeng.Value;
        }

        private void cmbPenColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            PenColor = (Pen)cmbPenColor.SelectedItem;
        }

  
    }
}
