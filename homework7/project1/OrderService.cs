using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

namespace project1
{
    public class OrderService
    {
        //private Dictionary<uint, Order> orders; 
       public static List<Order> orders = new List<Order>();
        public Order AddNewOrder(string ID, string Name)
        {
            Order order = new Order(ID, Name);
            orders.Add(order);
            return order;
        }    //添加新订单

        public void AddDetails(string item, uint number, double price, Order temp)
        {
            OrderDetails detail = new OrderDetails(item, number, price);
            if (temp.Items.Contains(detail))
            {
                throw new Exception($"orderDetails-{detail.Item} is already existed!");
            }
            temp.Items.Add(detail);
        }

        public void RemoveDetails(string temp1, Order temp2)
        {
            var item = temp2.Items.Single(m => m.Item == temp1);
            temp2.Items.Remove(item);
        }
        public IEnumerable<Order> Search(String temp)
        {
            var query = orders.Where(m => m.ID == temp || m.Name == temp);
            return query;
        }

        public bool ifExist(string temp)
        {
            var query = orders.Where(m => m.ID == temp || m.Name == temp);
            if (query.Count() != 0)
                return true;
            else
            {
                Console.WriteLine("无此数据！");
                return false;
            }
        }
        public void ReviseOrder(string temp1, string temp2, Order order)
        {
            if (temp1 == order.ID)
            {
                order.ID = temp2;
            }
            else if (temp1 == order.Name)
            {
                order.Name = temp2;
            }
            else
            {
                throw new ArgumentOutOfRangeException("No exits!");
            }
        }   //修改订单

        public void ReviseItem(string after, string item, Order order)
        {
            try {
                var temp = order.Items.Single(m => m.Item == item);
                temp.Item = after; }
            catch(ArgumentNullException e){
             string.Format("e.Message. {0} \n", e.Message); }
        }
        public void ReviseNumber(uint after, string item, Order order)
        {
            try
            {
                var temp = order.Items.Single(m => m.Item == item);
                temp.Num = after;
            }
            catch (ArgumentNullException e)
            {
                string.Format("e.Message. {0} \n", e.Message);
            }
        }
        public void RevisePrice(double after, string item, Order order)
        {
            try
            {
                var temp = order.Items.Single(m => m.Item == item);
                temp.Price = after;
            }
            catch (ArgumentNullException e)
            {
                string.Format("e.Message. {0} \n", e.Message);
            }
        }
 
        public List<Order> SearchOrderbyID(string temp)
        {
            var query = orders.Where(m => m.ID == temp);
            return query.ToList();
        }
        public List<Order> SearchOrderbyName(string temp)
        {
            var query = orders.Where(m => m.Name == temp);
            return query.ToList();
        }
        public List<Order> SearchPrice(double temp1, double temp2)
        {
            var query = orders.Where(m => m.TotalPrice >= temp1 && m.TotalPrice <= temp2);
            return query.ToList();
        }
        public List<Order> SearchPriceLessThan(double temp)
        {
            var query = orders.Where(m => m.TotalPrice <= temp);
            return query.ToList();
        }
        public List<Order> SearchPriceMoreThan(double temp)
        {
            var query = orders.Where(m => m.TotalPrice >= temp);
            return query.ToList();
        }
        public List<Order> SearchOrderbyItem(string temp)
        {
            var query = orders.Where(m => m.Items.Where
            (n => n.Item == temp).Count() > 0);
            return query.ToList();
        }
        public List<Order> SearchAllOrders()
        {
            var query = orders.AsEnumerable();
            return query.ToList();
        }
        //public void ShowOrderDetails(Order temp)
        //{
        //    Console.WriteLine("订单号：" + temp.ID + "\t姓名：" + temp.Name);
        //    foreach (OrderDetails n in temp.Items)
        //    {
        //        Console.WriteLine("\t商品：" + n.Item + "\t数量：" + n.Num + "\t价格：" + n.Price);
        //    }
        //}   //显示某个订单

        //public void ShowOrders()
        //{
        //    Console.WriteLine("Count:{0}", orders.Count);
        //    foreach (Order order in orders)
        //    {
        //        ShowOrderDetails(order);
        //        Console.WriteLine();
        //    }
        //}   //显示所有订单
        public static void XmlSerialize(XmlSerializer ser, string fileName, object obj)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();
        }
        public void Export(string fileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            XmlSerialize(xmlser, fileName, orders);
            string xml = File.ReadAllText(fileName);
        }
        public void Import(string fileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            orders = xmlser.Deserialize(fileStream)
                as List<Order>;
        }
        //public void Import1()
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    string xmlPath = @"D:\大二上学习资料\c#\CSharpHomework\homework6\project1\Order.xml";
        //    xmlDoc.Load(xmlPath);
        //    XmlNodeList orderList = xmlDoc.SelectNodes("//ArrayOfOrder//Order");  //创建 order 的list
        //    foreach (XmlNode order in orderList)       //遍历 <ArrayOfOrder> order
        //    {   
        //        XmlNodeList mOrderList = order.SelectNodes("Items//OrderDetails"); //获取 Order的子节点 id name items 列表
        //        string name = ((XmlElement)order).GetElementsByTagName("Name")[0].InnerText;
        //        string id = ((XmlElement)order).GetElementsByTagName("ID")[0].InnerText;
        //        Order temp = new Order(id, name);

        //        foreach (XmlNode mDetails in mOrderList)    // 遍历 mOrderList 列表 
        //        { 
        //            string Item = ((XmlElement)mDetails).GetElementsByTagName("Item")[0].InnerText;
        //            string Num = ((XmlElement)mDetails).GetElementsByTagName("Num")[0].InnerText;
        //            string Price = ((XmlElement)mDetails).GetElementsByTagName("Price")[0].InnerText;
        //            OrderDetails temp2 = new OrderDetails(Item,Convert.ToInt32(Num),Convert.ToDouble(Price));
        //            temp.Items.Add(temp2);
        //        }
        //        orders.Add(temp);
        //    }
        //}
    }
}