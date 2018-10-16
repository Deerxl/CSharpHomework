using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class OrderDetails
    {
        public string Item;  //商品名称
        public int Num;   //数量
        public double Price;  //价格
        public OrderDetails(string item, int num, double price)
        {
            Item = item;
            Num = num;
            Price = price;
        }
        //public static List<OrderDetails> orderDetails = new List<OrderDetails>();
    }
}
