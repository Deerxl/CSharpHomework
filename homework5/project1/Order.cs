using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class Order
    {
        public string ID;  //订单号
        public string Name;  //顾客姓名
        public List <OrderDetails> Items;
        public Order(string id, string name)
        {
            ID = id;
            Name = name;
            Items = new List<OrderDetails>();
        }
        //public static List<Order> orders = new List<Order>();
    }
}
