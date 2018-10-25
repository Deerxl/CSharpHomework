using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace project1
{
    public class OrderService
    {
        public static List<Order> orders = new List<Order>();
        public Order AddNewOrder(string ID, string Name)
        {
            Order order = new Order(ID, Name);
            orders.Add(order);
            return order;
        }    //添加新订单
        public void AddDetails(string item, int number, double price, Order temp)
        {
            OrderDetails details = new OrderDetails(item, number, price);
            temp.Items.Add(details);
        }

        public void RemoveDetails(string temp1, Order temp2)
        {
            var query2 = temp2.Items.Where(m => m.Item == temp1);
            foreach (OrderDetails m in query2)
            {
                temp2.Items.Remove(m);
                break;
            }

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
                Console.WriteLine("无此数据！修改失败！" +
                    "");
                return;
            }
        }   //修改订单

        public void ReviseItem(string after, string item, Order order)
        {
            var query = order.Items.Where(m => m.Item == item);
            if (query.Count() == 0)
            {
                Console.WriteLine("无此数据！修改失败！");
                return;
            }
            foreach (OrderDetails m in query)
                {
                    m.Item = after;
                    break;
                }
        }
        public void ReviseNumber(int after, string item, Order order)
        {
            var query = order.Items.Where(m => m.Item == item);
            if (query.Count() == 0)
            {
                Console.WriteLine("无此数据！修改失败！");
                return;
            }
            foreach (OrderDetails m in query)
            {
                m.Num = after;
                break;
            }
        }
        public void RevisePrice(double after, string item, Order order)
        {
            var query = order.Items.Where(m => m.Item == item);
            if (query.Count() == 0)
            {
                Console.WriteLine("无此数据！修改失败！");
                return;
            }
            foreach (OrderDetails m in  query)
            {
                m.Price = after;
                break;
            }
        }
        public void ShowOrderDetails(Order temp)
        {
            Console.WriteLine("订单号：" + temp.ID + "\t姓名：" + temp.Name);
            foreach (OrderDetails n in temp.Items)
            {
                Console.WriteLine("\t商品：" + n.Item + "\t数量：" + n.Num + "\t价格：" + n.Price);
            }
        }   //显示某个订单

        public void ShowOrders()
        {
            Console.WriteLine("Count:{0}", orders.Count);
            foreach (Order order in orders)
            {
                ShowOrderDetails(order);
                Console.WriteLine();
            }
        }   //显示所有订单
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