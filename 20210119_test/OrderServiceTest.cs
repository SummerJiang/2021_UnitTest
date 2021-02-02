using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static ExtractAndOverrideTest.OrderService;

namespace ExtractAndOverrideTest
{
    public partial class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Test_SyncBookOrders_3_Orders_Only_2_book_order()
        {
            var target = new StubOrderService();

            var orders = new List<Order>
            {
                new Order{ Type="Book", Price = 100, ProductName = "91's book"},
                new Order{ Type="CD", Price = 200, ProductName = "91's CD"},
                new Order{ Type="Book", Price = 300, ProductName = "POP book"},
            };
            target.SetOrders(orders);
            var count =target.GetTopBooksByOrders().Count();
            Assert.AreEqual(2, count);
        }


        //[Test]
        //public void Test_SyncBookOrders_1_Orders_NullData()
        //{
        //    var target = new StubOrderService();

        //    var orders = new List<Order>
        //    {
        //        new Order{ Type="CD", Price = 200, ProductName = "91's CD"}
        //    };
        //    target.SetOrders(orders);
        //    var count = target.GetTopBooksByOrders().Count();
        //    Assert.AreEqual(0, count);
        //}
    }
}