using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Tests
{
    internal static class Methods
    {
        // 比较两个集合是否相等
        public static bool EqualList<T>(List<T> source, List<T> target)
        {
            //空集合直接返回False,即使是两个都是空集合,也返回False
            if (source == null || target == null)
            {
                return true;
            }

            if (source.ToArray().Length != target.ToArray().Length)
                return false;

            int listLength = source.ToArray().Length;

            for (int i = 0; i < listLength; i++)
            {
                if (!source[i].Equals(target[i]))
                    return false;
            }

            return true;
        }
    }


    [TestClass()]
    public class OrderServiceTests
    {
        [TestInitialize()]
        public void OrdersInitialize()
        {
            orderService = new OrderService();

            Item book = new Item("book", 10, 10);
            Item milk = new Item("milk", 10, 2);
            Item car = new Item("car", 10000, 5);

            // 第一位顾客购买了2种商品
            order1 = new Order(new Customer("customer1"));
            order1.AddOrderItem(book, 2);
            order1.AddOrderItem(milk, 5);

            // 第二位顾客购买了3种商品
            order2 = new Order(new Customer("customer2"));
            order2.AddOrderItem(book, 3);
            order2.AddOrderItem(milk, 2);
            order2.AddOrderItem(car, 1);

            // 第三位顾客购买了1种商品
            order3 = new Order(new Customer("customer3"));
            order3.AddOrderItem(milk, 3);

            orderService.orders = new List<Order>() { order1, order2, order3 };
        }

        private OrderService orderService;
        private Order order1;
        private Order order2;
        private Order order3;

        [TestMethod()]
        public void AddOrderTest()
        {
            int beforeOrderAmount = orderService.OrderAmount;
            Customer NewCustomer = new Customer();
            orderService.AddOrder(NewCustomer);

            Assert.IsTrue(orderService.OrderAmount == beforeOrderAmount + 1);   // 数目增加了1
            Assert.AreEqual(orderService.orders.Last().customer, NewCustomer);  //新增的订单的顾客就是刚刚定义的顾客
        }

        [TestMethod()]
        public void FindIndexOfOrderTest()
        {
            int orderIndex = orderService.FindIndexOfOrder(order2.OrderNumber);
            Assert.AreEqual(1, orderIndex);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            orderService.DeleteOrder(order2.OrderNumber);

            Assert.IsTrue(orderService.OrderAmount == 2);
            Assert.AreEqual(orderService.orders[0], order1);
            Assert.AreEqual(orderService.orders[1], order3);
        }

        [TestMethod()]
        public void FindOrderTest()
        {
            // 通过顾客名检索
            var resultByCustomerName = orderService.FindOrder(order1.customer.CustomerName, (int)FinderSigns.ByCustomerName);
            Assert.IsTrue(Methods.EqualList(new List<Order>() { order1 }, resultByCustomerName.ToList()));

            // 通过物品名搜索
            var resultByItemName = orderService.FindOrder("book", (int)FinderSigns.ByItemName);
            Assert.IsTrue(Methods.EqualList(new List<Order>() { order1, order2 }, resultByItemName.ToList()));

            // 通过订单号搜索
            var resultByOrderNumber = orderService.FindOrder(order2.OrderNumber, (int)FinderSigns.ByOrderNumber);
            Assert.IsTrue(Methods.EqualList(new List<Order>() { order2 }, resultByOrderNumber.ToList()));
        }

        [TestMethod()]
        public void SortOrdersTest()
        {
            orderService.orders = new List<Order>() { order1, order2, order3 };
            List<Order> targetList = new List<Order>() { order3, order1, order2 };

            orderService.SortOrders();

            Assert.IsTrue(Methods.EqualList(orderService.orders, targetList));
        }

        [TestCleanup()]
        public void RecoverNumbers()
        {
            NumberManager.customerNumber = "000000";
            NumberManager.itemNumber = "000";
            NumberManager.orderNumber = "00000000";
        }
    }
}