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

namespace project1
{
    public partial class FormEdit : Form
    {
        Order order = new Order();
        public FormEdit()
        {
            InitializeComponent();
        }
        public Order getOrder()
        {
            return order;
        }
        public FormEdit(Order order) : this()
        {
            orderBindingSource.DataSource = order;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Order)orderBindingSource.Current).ID = Convert.ToString((Order)comboBox2.SelectedItem);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   ((Order)orderBindingSource.Current).Name = Convert.ToString((Order)comboBox1.SelectedItem);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentCell.Value != null)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            order = (Order)orderBindingSource.Current;
            this.Close();
        }
    }
}
