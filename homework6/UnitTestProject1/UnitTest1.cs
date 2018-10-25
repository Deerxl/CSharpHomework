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
        readonly string item2 = "dogfood";
        readonly int num = 2;
        readonly int num2 = 3;
        readonly double price = 99.9;
        readonly double price2 = 999.999;

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
        [TestMethod]
        public void ReviseOrderTest()
        {
            Order temp1 = new Order(id1, name1);

            OrderService tempTest = new OrderService();
            tempTest.ReviseOrder(id1, id2, temp1);
            Assert.IsTrue(id2 == temp1.ID || id2 == temp1.Name);
        }
        [TestMethod]
        public void ReviseItemTest()
        {
            Order temp1 = new Order(id1, name1);
            OrderDetails details = new OrderDetails(item, num, price);
            List<OrderDetails> detailsList = new List<OrderDetails>();
            temp1.Items = detailsList;
            temp1.Items.Add(details);

            OrderService tempTest = new OrderService();
            tempTest.ReviseItem(item2, item, temp1);
            Assert.IsTrue(temp1.Items.Exists(m => m.Item == item2));
        }
        [TestMethod]
        public void ReviseNumberTest()
        {
            Order temp1 = new Order(id1, name1);
            OrderDetails details = new OrderDetails(item, num, price);
            List<OrderDetails> detailsList = new List<OrderDetails>();
            temp1.Items = detailsList;
            temp1.Items.Add(details);

            OrderService tempTest = new OrderService();
            tempTest.ReviseNumber(num2, item, temp1);
            Assert.IsTrue(temp1.Items.Exists(m => m.Num == num2));
        }
        [TestMethod]
        public void RevisePriceTest()
        {
            Order temp1 = new Order(id1, name1);
            OrderDetails details = new OrderDetails(item, num, price);
            List<OrderDetails> detailsList = new List<OrderDetails>();
            temp1.Items = detailsList;
            temp1.Items.Add(details);

            OrderService tempTest = new OrderService();
            tempTest.RevisePrice(price2, item, temp1);
            Assert.IsTrue(temp1.Items.Exists(m => m.Price == price2));
        }
        [TestMethod]
        public void ExportTest()
        {
            Order temp1 = new Order(id1, name1);
            OrderDetails details = new OrderDetails(item, num, price);
            List<OrderDetails> detailsList = new List<OrderDetails>();
            temp1.Items = detailsList;
            temp1.Items.Add(details);

            OrderService tempTest = new OrderService();
            string fileNameTest = @"D:\大二上学习资料\c#\CSharpHomework\homework6\project1\orderTest.xml";
            //string fileName = @"D:\大二上学习资料\c#\CSharpHomework\homework6\project1\Order.xml";
            tempTest.Export(fileNameTest);
            Assert.IsNotNull(fileNameTest);
           // Assert.AreEqual(fileName, fileNameTest);
        }
        [TestMethod]
        public void ImportTest()
        {
            OrderService tempTest = new OrderService();
            OrderService.orders.Clear();
            string fileNameTest = @"D:\大二上学习资料\c#\CSharpHomework\homework6\project1\Order.xml";
            tempTest.Import(fileNameTest);
            Assert.IsTrue(OrderService.orders.Count != 0);
        }
    }
}
