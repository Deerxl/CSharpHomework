using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace project1 
{

    public class Program
    {
        public static void Main(string[] args)
        {
            menu temp2 = new menu();
            //OrderService temp2 = new OrderService();

            //Order order1 = new Order("20181016001", "xiaolu");
            //Order order2 = new Order("20181016002", "junyi");

            //OrderDetails details1 = new OrderDetails("kindle", 1, 2399);
            //OrderDetails details2 = new OrderDetails("ipad", 3, 13000);
            //OrderDetails details3 = new OrderDetails("iponeX", 2, 20000);

            //order1.Items = new List<OrderDetails>
            //{
            //    details1,
            //    details2,
            //    details3
            //};

            //List<OrderDetails> list = new List<OrderDetails>();
            //order2.Items = list;
            //order2.Items.Add(details2);
            

            //temp.Add(order1);
            //temp.Add(order2);
            temp2.OrderMenu();
        }
    }   
}