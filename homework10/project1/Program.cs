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
            OrderService orderService = new OrderService();

            OrderDetails details1 = new OrderDetails("1","kindle", 1, 2399);
            OrderDetails details2 = new OrderDetails("2","ipad", 3, 13000);
            OrderDetails details3 = new OrderDetails("3","iponeX", 2, 20000);

            List<OrderDetails> items1 = new List<OrderDetails> { details1, details2 };
            List<OrderDetails> items2 = new List<OrderDetails> { details3 };
            
            //order1.Items = new List<OrderDetails>
            //{
            //    details1,
            //    details2,
            //    details3
            //};
            Order order1 = new Order("20181016001", "xiaolu", "17362447819", items1);
            Order order2 = new Order("20181016002", "junyi", "13657872848", items2);
                         //List<OrderDetails> list = new List<OrderDetails>();
                         // order2.Items = list;
                         //order2.Items.Add(details2);

            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
        }
    }   
}