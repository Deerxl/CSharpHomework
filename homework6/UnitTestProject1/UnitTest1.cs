using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using project1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        string id = "20181022001";
        string name = "Alu";
        string item = "flower";
        int num = 2;
        double price = 99.9;

        [TestMethod]
        public void AddNewOrderTest()
        {
            Order temp = new Order(id, name);
            OrderDetails orderDetails = new OrderDetails(item, num, price);
           //List<OrderDetails> list = new List<OrderDetails>();
            //temp.Items = list;
            temp.Items.Add(orderDetails);
            //Assert.AreEqual(OrderService.AddNewOrder(id, name),temp);



            //OrderService temp = new project1.OrderService();
            // temp.Add(order);


            // project1.OrderService.orders.Add();
            //Assert.IsNull(OrderService.AddNewOrder());
        }
    }
}
