using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using project1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        readonly string id1 = "20181024001";
        readonly string name1 = "Alu";
        readonly string id2 = "20181024002";
        readonly string name2 = "junyi";
        readonly string item = "flower";
        readonly int num = 2;
        readonly double price = 99.9;

        [TestMethod]
        public void AddNewOrder()
        {
            OrderService tempTest = new OrderService();
            Order temp = tempTest.AddNewOrder(id1, name1);
            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void AddDetailsTest()
        {
            OrderService tempTest = new OrderService();
            Order temp1 = tempTest.AddNewOrder(id2, name2);
            tempTest.AddDetails(item, num, price, temp1);
            Assert.IsNotNull(temp1.Items);
        }

        [TestMethod]
        public void RemoveDetailsTest()
        {
            Order temp1 = new Order(id1, name1);
            OrderDetails details = new OrderDetails(item, num, price);
            List<OrderDetails> detailsList = new List<OrderDetails>();
            temp1.Items = detailsList;
            temp1.Items.Add(details);

            OrderService tempTest = new OrderService();
            tempTest.RemoveDetails(item, temp1);
            Assert.IsFalse(temp1.Items.Exists(m => m.Item == item));
        }
    }
}
