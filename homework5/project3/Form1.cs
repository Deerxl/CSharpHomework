using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics != null) graphics = this.CreateGraphics();
            drawTree(10, 200, 310, 100, -Math.PI / 2);
        }

        private Graphics graphics;

        static double temp1 = 30,temp2 = 20;
        double th1 = temp1 * Math.PI / 180;
        double th2 = temp2 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        void drawTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            double x2 = x0 + leng * Math.Sin(th);
            double y2 = y0 + leng * Math.Cos(th); 

            drawLine(x0, y0, x1, y1);
            drawLine(x0, y0, x2, y2);

            drawTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawTree(n - 1, x2, y2, per2 * leng, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            if (radioButton1.Checked)
            { 
                graphics.DrawLine(Pens.Black,
                (int)x0, (int)y0, (int)x1, (int)y1);
            }
            else if(radioButton2.Checked)
            {
                graphics.DrawLine(Pens.Blue,
                    (int)x0, (int)y0, (int)x1, (int)y1);
            }
            else if(radioButton3.Checked)
            {
                graphics.DrawLine(Pens.Red,
                    (int)x0, (int)y0, (int)x1, (int)y1);
            }
            else if(radioButton4.Checked)
            {
                graphics.DrawLine(Pens.Green,
                    (int)x0, (int)y0, (int)x1, (int)y1);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                temp1 = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                return;
            }
        }   //角度一

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                temp2 = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                return;
            }
        }   //角度二
    }
}
