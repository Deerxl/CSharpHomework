using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class OrderService
    {
        public static List<Order> orders = new List<Order>();

        public void EnterOrder()
        {
                Console.WriteLine("请输入你想进入操作的订单号或姓名；");
                String temp = Console.ReadLine();
                var query1 = from mOrder in orders
                             where temp == mOrder.ID || temp == mOrder.Name
                             select mOrder;
            if (query1.Count() == 0)
            {
                Console.WriteLine("没有此订单！");
            }
            else
            {
                try
                {
                    bool TEMP = true;
                    while (TEMP)
                    {
                        Console.WriteLine("1.添加条目" + "\t2.删除条目" + "\t3.查找条目" + "\t4.其余键返回主菜单");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("请输入要添加的条目的商品名称、数量、价格");
                                string Item = Console.ReadLine();
                                int Number = Convert.ToInt32(Console.ReadLine());
                                double Price = Convert.ToDouble(Console.ReadLine());
                                OrderDetails M = new OrderDetails(Item, Number, Price);
                                foreach (Order n in query1)
                                {
                                    n.Items.Add(M);
                                    Console.WriteLine("添加成功！");
                                    break;
                                }
                                break;
                            case "2":
                                Console.WriteLine("请输入要删除的商品：");
                                string Temp = Console.ReadLine();
                                foreach (Order n in query1)
                                {
                                    var query2 = n.Items.Where(m => m.Item == Temp);
                                    foreach (OrderDetails m in query2)
                                    {
                                        n.Items.Remove(m);
                                        Console.WriteLine("删除成功！");
                                        break;
                                    }
                                }
                                break;
                            case "3":
                                Console.WriteLine("请输入要筛选的订单的价位区间：");
                                double Temp1 = Convert.ToDouble(Console.ReadLine());
                                double Temp2 = Convert.ToDouble(Console.ReadLine());
                                foreach (Order n in query1)
                                {
                                    Console.WriteLine("订单号：" + n.ID + "\t姓名：" + n.Name);
                                    var query2 = n.Items.Where(m => m.Price >= Temp1 && m.Price <= Temp2);
                                    foreach (OrderDetails m in query2)
                                    {
                                        Console.WriteLine("\t商品：" + m.Item + "\t数量：" + m.Num + "\t价格：" + m.Price);
                                    }
                                    Console.WriteLine();
                                }
                                break;
                            default:
                                TEMP = false;
                                return;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("请输入有效的数据！");
                }
            }

        }
        public void Add(Order temp)
        {
            orders.Add(temp);
        }
        public void AddNewOrder()
        {
            Console.WriteLine("请输入：订单号、客户:");
            string ID = Console.ReadLine();
            string Name = Console.ReadLine();
            Order order = new Order(ID, Name);
            order.Items = new List<OrderDetails>();
            Console.WriteLine("请输入订单物品详细信息：名称、数量、价格（输入-1结束）");
            try
            {
                bool temp = true;
                while (temp)
                {
                    string Item = Console.ReadLine();               
                    var str1 = Console.ReadLine();
                    int Number = Convert.ToInt32(str1);
                    var str2 = Console.ReadLine();
                    double Price = Convert.ToDouble(str2);     
                    OrderDetails details = new OrderDetails(Item, Number, Price);
                    order.Items.Add(details);
                    if ("-1" == Console.ReadLine())
                    {
                        temp = false;
                    }
                }
                orders.Add(order);
                Console.WriteLine("添加成功！");
            }
            catch
            {
                Console.WriteLine("请输入正确的订单信息！");
            }
            
        }    //添加新订单
        public void AddOrderDetails(Order N)
        {
            Console.WriteLine("请输入订单物品详细信息：名称、数量、价格（输入-1结束）");
            try
            {
                bool temp = true;
                while (temp)
                {
                    string Item = Console.ReadLine();
                    var str1 = Console.ReadLine();
                    int Number = Convert.ToInt32(str1);
                    var str2 = Console.ReadLine();
                    double Price = Convert.ToDouble(str2);
                    OrderDetails details = new OrderDetails(Item, Number, Price);
                    N.Items.Add(details);
                    Console.WriteLine("添加成功！");
                    if ("-1" == Console.ReadLine())
                    {
                        temp = false;
                    }
                }
            }
            catch
            {
                Console.WriteLine("请输入正确的订单信息！");
            }
        }

        public void RemoveOrder()
        {
            Console.WriteLine("请输入要删除的订单号或名称：");
            string temp = Console.ReadLine();
            var query = orders.Where(mOrder => mOrder.ID == temp || mOrder.Name == temp);
            if(query.Count() == 0)
            {
                Console.WriteLine("没有找到要删除的订单！");
                return;
            }
            else
            {
                foreach (Order mOrder in query)
                {
                    orders.Remove(mOrder);
                    Console.WriteLine("订单删除成功！");
                    break;
                }   
            }
        }   //删除订单

        public void SearchOrder()
        {
            Console.WriteLine("请输入要查找的订单号或姓名：");
            String temp = Console.ReadLine();
            var query1 = from mOrder in orders
                         where temp == mOrder.ID || temp == mOrder.Name
                         select mOrder;
            if(query1.Count() == 0)
            {
                Console.WriteLine("对不起，查找不到所需数据！");
                return;
            }
            else
            {
                Console.WriteLine("以下是查询结果：");
                foreach (Order n in query1)
                {
                    ShowOrderDetails(n);
                }
            }
        }  //查找订单

        public void ReviseOrder()
        {
            Console.WriteLine("请输入所需要修改的订单（订单号或姓名）和修改之后的值：");
            string temp1 = Console.ReadLine();
            string temp2 = Console.ReadLine();
            var query1 = orders.Where(mOrder => mOrder.ID == temp1 || mOrder.Name == temp1);
            if (query1.Count() == 0)
            {
                Console.WriteLine("对不起，查找不到所需要修改的数据！");
                return;
            }
            else
            {
                foreach (Order mOrder in query1)
                {
                    if (temp1 == mOrder.ID)
                    {
                        mOrder.ID = temp2;
                    }
                    else if (temp1 == mOrder.Name)
                    {
                        mOrder.Name = temp2;
                    }
                    Console.WriteLine("修改成功！");
                    ShowOrderDetails(mOrder);
                    break;
                }
            }
        }   //修改订单

        public void SelectOrder()
        {
            Console.WriteLine("请输入要查找的订单号或姓名：");
            try
            {
                String temp = Console.ReadLine();
                var query1 = from mOrder in orders
                             where temp == mOrder.ID || temp == mOrder.Name
                             select mOrder;
                if (query1.Count() == 0)
                {
                    Console.WriteLine("对不起，查找不到所需数据！");
                    return;
                }
                else
                {
                    Console.WriteLine("请输入你想要筛选的价格区间：");
                    double temp1 = Convert.ToDouble(Console.ReadLine());
                    double temp2 = Convert.ToDouble(Console.ReadLine());
                    foreach (Order n in query1)
                    {
                        Console.WriteLine("订单号：" + n.ID + "\t姓名：" + n.Name);
                        var query2 = n.Items.Where(m => m.Price >= temp1 && m.Price <= temp2);
                        if (query2.Count() == 0)
                        {
                            Console.WriteLine("没有在此范围内的订单！");
                            return;
                        }
                        else
                        {
                            foreach (OrderDetails m in query2)
                            {
                                Console.WriteLine("\t商品：" + m.Item + "\t数量：" + m.Num + "\t价格：" + m.Price);
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("请输入有效的数据！");
            }

        } //筛选订单

        public void ShowOrderDetails(Order temp)
        {
            Console.WriteLine("订单号：" + temp.ID  + "\t姓名：" + temp.Name);
            foreach(OrderDetails n in temp.Items)
            {
                Console.WriteLine("\t商品：" + n.Item + "\t数量：" + n.Num + "\t价格：" + n.Price);
            }
        }   //显示某个订单

        public void ShowOrders()
        { 
            Console.WriteLine("以下是所有订单：");
            Console.WriteLine("Count:{0}", orders.Count);
            foreach (Order order in orders)
            {
                Console.WriteLine("订单号：" + order.ID + "\t姓名：" + order.Name);
                foreach (OrderDetails n in order.Items)
                {
                    Console.WriteLine("\t商品：" + n.Item + "\t数量：" + n.Num + "\t价格：" + n.Price);
                }
                Console.WriteLine();
            }
        }   //显示所有订单

        public void OrderMenu()
        {
            string temp;
            bool ifCircle = true ;
            while(ifCircle)
            {
                Console.WriteLine("菜单：");
                Console.WriteLine("1.添加订单" + "\t2.删除订单" + "\t3.查询订单" + "\t4.修改订单" + "\t5.筛选订单" + "\t6.查看所有订单" +"\t7.进入订单" + "\t8.其它任意键退出");
                temp = Console.ReadLine();
                switch (temp)
                {
                    case "1":
                        AddNewOrder();
                        break;
                    case "2":
                        RemoveOrder();
                        break;
                    case "3":
                        SearchOrder();
                        break;
                    case "4":
                        ReviseOrder();
                        break;
                    case "5":
                        SelectOrder();
                        break;
                    case "6":
                        ShowOrders();
                        break;
                    case "7":
                        EnterOrder();
                        break;
                    default:
                        ifCircle = false;
                        break;
                }
            }
        }//菜单

    }
}