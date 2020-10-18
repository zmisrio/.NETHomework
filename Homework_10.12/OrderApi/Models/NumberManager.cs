using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Model
{
    // 静态类，分别为顾客、商品、订单分配序号
    public static class NumberManager
    {
        public static string customerNumber = "000000";            //六位顾客编号
        public static string itemNumber = "000";                   //三位物品编号
        public static string orderNumber = "00000000";             //八位订单编号
        public static string shopNumber = "00";                    //两位商店编号
        public static string orderServiceNumber = "0000";
        public static string orderItemNumber = "000";

        public static string GetOrderItemNumber()
        {
            int intNumber = int.Parse(orderItemNumber) + 1;
            orderItemNumber = intNumber.ToString().PadLeft(3, '0');

            return orderItemNumber;
        }

        public static string GetOrderServiceNumber()
        {
            int intNumber = int.Parse(orderServiceNumber) + 1;
            orderServiceNumber = intNumber.ToString().PadLeft(4, '0');

            return orderServiceNumber;
        }

        public static string GetShopNumber()
        {
            int intNumber = int.Parse(shopNumber) + 1;
            shopNumber = intNumber.ToString().PadLeft(2, '0');

            return shopNumber;
        }


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
