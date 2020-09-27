using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderSystem
{
    public enum FinderSigns
    {
        ByOrderNumber = 0,
        ByItemName = 1,
        ByCustomerName = 2
    }

    public class OrderService
    {
        public List<Order> orders;
        public int OrderAmount { get => orders.ToArray().Length; }

        public OrderService()
        {
            orders = new List<Order>();
        }

        // 该种方法根据顾客名添加订单，且订单号随机生成，保证了添加的订单号不会重复
        public void AddOrder(Customer customer)
        {
            orders.Add(new Order(customer));
        }

        // 根据订单序号查找其索引值
        public int FindIndexOfOrder(string orderNumber)
        {
            int i = 0;
            foreach (Order order in orders)
            {
                if (order.OrderNumber == orderNumber)
                    return i;
                i++;
            }
            throw new OrderNotExist(orderNumber);
        }

        // 根据订单序号删除订单，当订单号不存在时，抛出异常
        public void DeleteOrder(string orderNumber)
        {
            int index = FindIndexOfOrder(orderNumber);
            orders.RemoveAt(index);
        }

        // 索引订单，可根据顾客名、订单号、商品名进行索引
        public IEnumerable<Order> FindOrder(string inputString, int sign)
        {
            switch ((FinderSigns)sign)
            {
                case FinderSigns.ByCustomerName:
                    {
                        inputString = inputString.ToUpper();
                        var query = from order in orders
                                    where order.customer.CustomerName == inputString
                                    orderby order.TotalPrice
                                    select order;
                        if (query.FirstOrDefault() != null)
                            return query;
                        else
                            throw new CustomerNotExistException(inputString);
                    }
                case FinderSigns.ByItemName:
                    {
                        inputString = inputString.ToUpper();
                        var query = from order in orders
                                    where order.Contains(inputString)
                                    orderby order.TotalPrice
                                    select order;
                        if (query.FirstOrDefault() != null)
                            return query;
                        else
                            throw new OrderItemNotExist(inputString);
                    }
                case FinderSigns.ByOrderNumber:
                    {
                        var query = from order in orders
                                    where order.OrderNumber == inputString
                                    orderby order.TotalPrice
                                    select order;
                        if (query.FirstOrDefault() != null)
                            return query;
                        else
                            throw new OrderNotExist(inputString);
                    }
                default:
                    throw new InvalidSearchException();
            }
        }

        // 根据购买物品数量排序
        public void SortOrders()
        {
            orders.Sort((order1, order2) => (order1.OrderItemAmount - order2.OrderItemAmount));
        }

        public void PrintOrders()
        {
            if (OrderAmount > 0)
            {
                Console.WriteLine("您的订单为：");
                for (int i = 0; i < OrderAmount; i++)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("订单" + (i + 1) + ":");
                    Console.Write(orders[i]);
                    Console.WriteLine(" ");
                }
            }
            else
            {
                Console.WriteLine("您目前还没有订单哦！");
            }
        }

        public void Export(string xmlFilePath)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Create))
            {
                xmlser.Serialize(fs, orders);
            }
        }

        public void Import(string xmlFilePath)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open))
            {
                orders = (List<Order>)xmlser.Deserialize(fs);
            }
        }
    }
}
