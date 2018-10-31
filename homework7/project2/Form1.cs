using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using project1;

namespace project2
{
    public partial class Form1 : Form
    {
        OrderService temp = new OrderService();
        public static List<Order> orders = new List<Order>();

        public string KeyWord { get; set; }
        public Form1()
        {
            InitializeComponent();
            orderbindingSource.DataSource = orders;
            IsMdiContainer = true;
            //Order order1 = temp.AddNewOrder("320", "xl");
            //OrderDetails details1 = new OrderDetails("dogfood", 2, 99.9);
            //OrderDetails details2 = new OrderDetails("dogfood", 1, 999.9);
            //order1.Items = new List<OrderDetails> { details1, details2 };
            //orders.Add(order1);

            //textBox1.DataBindings.Add("Text", this, "KeyWord");//绑定查询条件
            //textBox3.DataBindings.Add("Text", this, "KeyWord");
            //textBox4.DataBindings.Add("Text", this, "KeyWord");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Order> ts;
            if (textBox1.Text == null && textBox3.Text == null && textBox4.Text == null)
            {
                label5.Text = Convert.ToString("共" + orders.Count + "条记录");
            }
            else if (textBox1.Text != null)
            {
                ts = temp.SearchOrder(textBox1.Text);
                orderbindingSource.DataSource = ts;
                label5.Text = Convert.ToString("共" + ts.Count() + "条记录");
            }
            else if (textBox3.Text != null && textBox4.Text != null)
            {
                ts = temp.SearchPrice(Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text));
                orderbindingSource.DataSource = ts;
                label5.Text = Convert.ToString("共" + ts.Count() + "条记录");
            }
            else if (textBox3.Text == null && textBox4.Text != null)
            {
                ts = temp.SearchPriceLessThan(Convert.ToDouble(textBox4.Text));
                orderbindingSource.DataSource = ts;
                label5.Text = Convert.ToString("共" + ts.Count() + "条记录");
            }
        }   //select order by ID, Name, Price

        private void button5_Click(object sender, EventArgs e)
        {
           openFileDialog1.ShowDialog();
           string fileName = openFileDialog1.FileName;
           temp.Import(fileName);
        }   //import

        private void button6_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string fileName = saveFileDialog1.FileName;
            temp.Export(fileName);
        }   //export

        private void button2_Click(object sender, EventArgs e)   //add
        {
            addForm addForm = new addForm();
            addForm.ShowDialog();
            //ShowDialog();
            //addForm.MdiParent = this;
           //addForm.ShowDialog();
        }
    }
}
