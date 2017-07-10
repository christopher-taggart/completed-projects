using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using NUnit.Framework;
using NUnit.Framework.Internal;


namespace FlooringMastery.Tests
{
    [TestFixture]
    public class OrderTests
    {
        private const string _testData =
                @"C:\Users\Chris\Documents\chris.taggart.self.work\Labs\FlooringMasteryComplete\TestData\Orders_01012018.txt"
            ;
        private const string _originalData =
            @"C:\Users\Chris\Documents\chris.taggart.self.work\Labs\FlooringMasteryComplete\TestData\TestOrderDataSeed.txt";

        
        [SetUp]
        public void Setup()
        {
            
            if (File.Exists(_testData))
            {
                File.Delete(_testData);
            }

            File.Copy(_originalData, _testData);
        }
       
        //Lookup / Load
        [TestCase("6/12/20", false)]
        [TestCase("1/1/18", true)]
        public void CanLoadOrderTest(string date, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
           
            OrderListResponse response = manager.GetOrdersByDate(date);
            
            
            Assert.AreEqual(expectedResult, response.Success);

        }

        //Rules
        [TestCase("6/12/19", "Test", "ohio", "wood", 150, true)]
        [TestCase("1/1/15","Test", "ohio", "wood", 150, false)]
        [TestCase("1/1/20", "Test", "texas", "wood", 150, false)]
        [TestCase("1/1/20", "Test", "ohio", "wood", 99, false)]
        [TestCase("1/1/20", "Test", "ohio", "nothing", 150, false)]
        public void ValidateAddOrderTest(string date, string name, string state, string product, decimal area,
            bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderResponse response = manager.AddOrder(date, name, state, product, area);
            Assert.AreEqual(expectedResult, response.Success);
        }

        //Remove
        [TestCase("1/1/2018", 1)]
        public void CanRemoveOrderTest(string date, int orderNumber)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderListResponse response = manager.GetOrdersByDate(date);

            Assert.AreEqual(2, response.Orders.Count);

            manager.RemoveOrder(response.Orders, orderNumber, date);

            Assert.AreEqual(1, response.Orders.Count);
        }

        //Edit
        [TestCase("1/1/18", "Edited", "OH", "Tile", 150, 1)]
        public void CanEditOrderTest(string date, string name, string state, string pType, decimal area, int orderNumber)
        {

            OrderManager manager = OrderManagerFactory.Create();
            OrderListResponse response = manager.GetOrdersByDate(date);
            OrderResponse r = manager.EditOrder(date, name, state, pType, area, orderNumber);

            manager.RemoveOrder(response.Orders, orderNumber, date);
            manager.SaveOrder(r.Order, date);
            response = manager.GetOrdersByDate(date);
            Order editedOrder = response.Orders[0];
            
            Assert.AreEqual(name, editedOrder.CustomerName);
            Assert.AreEqual(state, editedOrder.State);
            Assert.AreEqual(pType, editedOrder.ProductType);
            Assert.AreEqual(area, editedOrder.Area);
        }

        //Save
        [TestCase("1/1/18", "New Order", "OH", "Tile", 200)]
        public void CanSaveOrderTest(string date, string name, string state, string pType, decimal area)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderListResponse orders = manager.GetOrdersByDate(date);

            Assert.AreEqual(2, orders.Orders.Count);

            OrderResponse newOrder = manager.AddOrder(date, name, state, pType, area);
            
            manager.SaveOrder(newOrder.Order, date);
            orders = manager.GetOrdersByDate(date);
            
            Assert.AreEqual(3, orders.Orders.Count);
        }

        //Order number
        [TestCase("1/1/2018", 3)]
        [TestCase("1/2/2018", 1)]
        public void GetCustomerOrderNumberTest(string date, int expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            int testNumber = manager.GetCustomerOrderNumber(date);

            Assert.AreEqual(expectedResult, testNumber);
        }
    }
}
