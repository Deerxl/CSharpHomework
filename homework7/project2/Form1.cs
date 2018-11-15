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
        OrderService orderService = new OrderService();
        public static List<Order> orders = new List<Order>();
        //BindingSource bindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            orderBindingSource.DataSource = orders;

            //Order order1 = orderService.AddNewOrder("320", "xl");
            //OrderDetails details1 = new OrderDetails("dogfood", 2, 99.9);
            //OrderDetails details2 = new OrderDetails("dogfood", 1, 999.9);
            //order1.Items = new List<OrderDetails> { details1, details2 };
            //orders.Add(order1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    orderBindingSource.DataSource = orderService.SearchOrderbyID(textBox1.Text);
                    break;
                case 1:
                    orderBindingSource.DataSource = orderService.SearchOrderbyName(textBox1.Text);
                    break;
                case 2:
                    orderBindingSource.DataSource = 
                        orderService.SearchPriceMoreThan(Convert.ToDouble(textBox1.Text));
                    break;
                case 3:
                    orderBindingSource.DataSource =
                       orderService.SearchPriceLessThan(Convert.ToDouble(textBox1.Text));
                    break;
                case 4:
                    orderBindingSource.DataSource =
                        orderService.SearchOrderbyItem(textBox1.Text);
                    break;
                case 5:
                    orderBindingSource.DataSource =
                        orderService.SearchAllOrders();
                    break;                  
            }
        }  //search
        private void button2_Click(object sender, EventArgs e)
        {
            FormEdit addform = new FormEdit(new Order());
            addform.ShowDialog();
            Order newOrder = addform.getOrder();
            if(newOrder != null)
            orders.Add(newOrder);
        }  //add

        private void button3_Click(object sender, EventArgs e)
        {
            Order del = (Order)orderBindingSource.Current;
            if(del != null)
            orders.Remove(del);
        }  //delete

        private void button4_Click(object sender, EventArgs e)
        {
            FormEdit reviseform = new FormEdit((Order)orderBindingSource.Current);
            reviseform.ShowDialog();

        }    // revise

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult butResult = openFileDialog1.ShowDialog();
            if (butResult.Equals(DialogResult.OK))
            {
                string filename = openFileDialog1.FileName;
                orderService.Import(filename);
                //orderBindingSource.DataSource = orders;
            }
        }      //import  

        private void button6_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string filename = saveFileDialog1.FileName;
            orderService.Export(filename);
        } //export
    }
}
