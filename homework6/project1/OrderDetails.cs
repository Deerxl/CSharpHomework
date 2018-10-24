using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    [Serializable]
    public class OrderDetails
    {

        public string Item { set; get; }  //商品名称
        public int Num { set; get; }   //数量
        public double Price{ set; get; }  //价格
        public OrderDetails() { }
        public OrderDetails(string item, int num, double price)
        {
            this.Item = item;
            this.Num = num;
            this.Price = price;
        }
        //public static List<OrderDetails> orderDetails = new List<OrderDetails>();
    }
}
