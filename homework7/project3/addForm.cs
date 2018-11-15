using project1;
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
    public partial class addForm : Form
    {
        List<Order> temp = new List<Order>();
        public Form1 mainForm;
        public addForm(Form1 form1)
        {
            mainForm = form1;
            InitializeComponent();
            
            temp = Form1.orders;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
           // form1.temp.SearchOrder(textBox6.Text);

        }

        public void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1 = (Form1)this.Owner;
            Order order1 = new Order(textBox1.Text, textBox2.Text);
            OrderDetails details1= new OrderDetails(textBox7.Text, Convert.ToUInt32(textBox8.Text), Convert.ToDouble(textBox9.Text));
            order1.Items.Add(details1);
            //order1.Items = new List<OrderDetails> { details1 };
            //form1.orderpass = order1;
            temp.Add(order1);
            Form1.orders = temp;
            this.Close();
            
            //return order1;
            //form1.temp.AddNewOrder(textBox1.Text, textBox2.Text);
            //form1.temp.AddDetails(textBox7.Text, Convert.ToUInt32(textBox8.Text), Convert.ToDouble(textBox9.Text), form1.temp.AddNewOrder(textBox1.Text, textBox2.Text));
            //form1.orders.Add(form1.temp.AddNewOrder(textBox1.Text, textBox2.Text));
        }
    }
}
