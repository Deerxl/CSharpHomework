using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace project1
{
    [Serializable]
    public class Order
    {
        public string ID { set; get; }
        public string Name { set; get; }
       // public string ID;  //订单号
       // public string Name;  //顾客姓名
        public List <OrderDetails> Items;
        public Order() { }
        public Order(string id, string name)
        {
            this.ID = id;
            this.Name = name;
            Items = new List<OrderDetails>();
        }
        //public static List<Order> orders = new List<Order>();
    }
}
