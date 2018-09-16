using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
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
            string s1 = textBox1.Text;
            double d1 = double.Parse(s1);
            string s2 = textBox2.Text;
            double d2 = double.Parse(s2);
            double multip = d1 * d2;
            label3.Text = $"{d1}和{d2}的乘积是：" + multip;
        }
    }
}
