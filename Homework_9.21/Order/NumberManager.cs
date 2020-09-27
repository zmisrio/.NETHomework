using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    // 静态类，分别为顾客、商品、订单分配序号
    public static class NumberManager
    {
        public static string customerNumber = "000000";            //六位顾客编号
        public static string itemNumber = "000";                   //三位物品编号
        public static string orderNumber = "00000000";             //八位订单编号

        public static string GetCustomerNumber()
        {
            int intNumber = int.Parse(customerNumber) + 1;
            customerNumber = intNumber.ToString().PadLeft(6, '0');

            return customerNumber;
        }

        public static string GetItemNumber()
        {
            int intNumber = int.Parse(itemNumber) + 1;
            itemNumber = intNumber.ToString().PadLeft(3, '0');

            return itemNumber;
        }

        public static string GetOrderNumber()
        {
            int intNumber = int.Parse(orderNumber) + 1;
            orderNumber = intNumber.ToString().PadLeft(8, '0');

            return orderNumber;
        }
    }
}
