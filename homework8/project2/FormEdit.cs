using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace project1
{
    public partial class FormEdit : Form
    {
        Order temp = null;
        List<OrderDetails> detailList = new List<OrderDetails>();
        public FormEdit()
        {
            InitializeComponent();
        }
        public Order getOrder()
        {
            return temp;
        }
        public FormEdit(Order order) : this()
        {
            orderBindingSource.DataSource = order;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Regex idTest = new Regex(@"\d{4}((0[1-9])|(1[0-2]))(([0-2][0-9])|(3[01]))\d{3}");
            bool ok = idTest.IsMatch(textBox1.Text);
            
            Regex phoneDianxinTest = new Regex(@"^1[3578][01379]\d{8}$");
            Regex phoneLiantongTest = new Regex(@"^1[34578][01256]\d{8}$");
            Regex phoneYidongTest = new Regex(@"^(134[012345678]\d{7}|1[34578][012356789]\d{8})$");
            bool ok_2 = (
                phoneDianxinTest.IsMatch(textBox2.Text)||
                phoneLiantongTest.IsMatch(textBox2.Text)||
                phoneYidongTest.IsMatch(textBox2.Text));
            if (textBox1.Text == null || comboBox2.Text == null)
            {
                MessageBox.Show("订单号/姓名不能为空！");
            }
            else if (ok == false)
            {
                MessageBox.Show("订单号格式不正确！");
            }
            else if (ok_2 == false)
            {
                MessageBox.Show("电话号码格式不正确！");
            }
            else
            {
                temp = new Order();
                ((Order)orderBindingSource.Current).ID = textBox1.Text;
                ((Order)orderBindingSource.Current).Name = comboBox2.Text;
                ((Order)orderBindingSource.Current).phoneNum = textBox2.Text;
                //if (((Order)orderBindingSource.Current).Items == null)
                //{
                //    ((Order)orderBindingSource.Current).Items.Add(new OrderDetails());
                //}
                List<OrderDetails> detailList = new List<OrderDetails>();

                foreach (DataGridViewRow rows in dataGridView1.Rows)
                {
                    if (rows.Cells[0].Value == null)
                        break;
                    OrderDetails detail = new OrderDetails(
                        rows.Cells[0].Value.ToString(),
                        Convert.ToUInt32(rows.Cells[1].Value),
                        Convert.ToDouble(rows.Cells[2].Value));
                    detailList.Add(detail);
                }
            ((Order)orderBindingSource.Current).Items = detailList;
                temp = (Order)orderBindingSource.Current;
                ///MessageBox.Show("添加成功");
                this.Close();
            }
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            textBox1.Text = ((Order)orderBindingSource.Current).ID;
            comboBox2.SelectedItem = ((Order)orderBindingSource.Current).Name;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
