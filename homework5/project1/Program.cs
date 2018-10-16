using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace project1 
{

    public class program
    {
        public static void Main(string[] args)
        {
            Order order1 = new Order("20181016001", "xiaolu");
            Order order2 = new Order("20181016002", "junyi");

            OrderDetails details1 = new OrderDetails("kindle", 1, 2399);
            OrderDetails details2 = new OrderDetails("ipad", 3, 13000);
            OrderDetails details3 = new OrderDetails("iponeX", 2, 20000);

            order1.Items = new List<OrderDetails>();
            order1.Items.Add(details1);
            order1.Items.Add(details2);
            order1.Items.Add(details3);

            order2.Items = new List<OrderDetails>();
            order2.Items.Add(details2);

            OrderService temp = new OrderService();
            temp.Add(order1);
            temp.Add(order2);
            temp.OrderMenu();
        }
    }   
}