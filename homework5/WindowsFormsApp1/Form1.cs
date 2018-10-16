using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawTree(10, 200, 310, 100, -Math.PI / 2);
        }

        private Graphics graphics;
        
        public double temp1 = 40;
        public double temp2 = 30;

        public double per1 = 0.6;
        public double per2 = 0.7;
        public int LineWidth = 1;

        Random rnd = new Random();
        double rand()
        {
            return rnd.NextDouble();
        }
        void drawTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double th1 = temp1 * Math.PI / 180;
            double th2 = temp2 * Math.PI / 180;

            double x1 = x0 + leng * Math.Cos(th); //设置分支1
            double y1 = y0 + leng * Math.Sin(th);

            double x2 = x1; //设置分支2
            double y2 = y1;

            if (checkBox1.Checked)
            {
                drawLine(x0 + rand(), y0 + rand(), x1 + rand(), y1 + rand());
                drawLine(x0 + rand(), y0 + rand(), x2 + rand(), y2 + rand());

                drawTree(n - 1, x1 + rand(), y1 + rand(), per1 * leng * (0.5 + rand()), th + th1 * (0.5 + rand()));
                drawTree(n - 1, x2 + rand(), y2 + rand(), per2 * leng * (0.4 + rand()), th - th2 * (0.5 + rand()));
                if (rand() > 0.6)
                {
                    drawLine(x0 + rand(), y0 + rand(), x1 + rand(), y1 + rand());
                    drawLine(x0 + rand(), y0 + rand(), x2 + rand(), y2 + rand());

                    drawTree(n - 1, x1 + rand(), y1 + rand(), per2 * leng * (0.4 + rand()), th - th2 * (0.5 + rand()));
                    drawTree(n - 1, x1 + rand(), y1 + rand(), per2 * leng * (0.4 + rand()), th - th2 * (0.5 + rand()));
                }
                   

            }
            else
            {
                drawLine(x0, y0 , x1, y1);
                drawLine(x0, y0 , x2, y2);

                drawTree(n - 1, x1, y1, per1 * leng, th + th1);
                drawTree(n - 1, x2, y2, per2 * leng, th - th2);
            }
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            if (radioButton1.Checked)
            {
                Pen temp = new Pen(Color.Black, LineWidth);
                graphics.DrawLine(temp, (int)x0, (int)y0, (int)x1, (int)y1);
            }
            else if (radioButton2.Checked)
            {
                Pen temp = new Pen(Color.Blue, LineWidth);
                graphics.DrawLine(temp, (int)x0, (int)y0, (int)x1, (int)y1);
            }
            else if (radioButton3.Checked)
            {
                Pen temp = new Pen(Color.Brown, LineWidth);
                graphics.DrawLine(temp, (int)x0, (int)y0, (int)x1, (int)y1);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                temp1 = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                return;
            }
        }  //角度一

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LineWidth = Convert.ToInt32(textBox3.Text);
            }
            catch{return;}
        }  //线宽

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                temp2 = Convert.ToDouble(textBox2.Text);
            }
            catch
            {
                return;
            }
        }   //角度二

    }
}
