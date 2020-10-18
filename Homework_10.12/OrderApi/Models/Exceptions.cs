using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 一些自定义的异常类
namespace OrderApp.Model
{
    // 某件商品数量不足的异常
    public class SoldOutException : ApplicationException
    {
        public string Description { get; set; }
        public int ItemLeftAmout { get; set; }          // 还剩多少件
        public SoldOutException(string description,int leftAmount)
        {
            this.Description = description;
            this.ItemLeftAmout = leftAmount;
        }
    }

    // 某件商品不在商店中的异常
    public class NotInShopException : ApplicationException
    {
        public string Description { get; set; }
        public NotInShopException(string description)
        {
            this.Description = description;
        }
    }

    // 订单不存在的异常
    public class OrderNotExist : ApplicationException
    {
        public string OrderNumber { get; set; }
        public OrderNotExist(string orderNumber)
        {
            this.OrderNumber = orderNumber;
        }
    }

    // 某件商品不在订单明细中的异常
    public class OrderItemNotExist :ApplicationException
    {
        public string Description { get; set; }
        public OrderItemNotExist(string description)
        {
            Description = description;
        }
    }

    public class CustomerNotExistException :ApplicationException
    {
        public string CustomerName { get; set; }
        public CustomerNotExistException(string customerName)
        {
            CustomerName = customerName;
        }
    }

    public class InvalidSearchException :ApplicationException{ }
}
