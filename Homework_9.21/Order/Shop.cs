using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    // 商店类
    public class Shop
    {
        List<Item> items;                   // 商店中已有的货物，可以理解为仓库
        public OrderService OrderService;

        public Shop()
        {
            items = new List<Item>();
            OrderService = new OrderService();
        }

        public void AddItem(string description, double price, int quantity)
        {
            Item item = new Item(description, price, quantity);
            items.Add(item);
            itemQuantity++;
        }

        // 根据商品名称寻找商品的索引
        public int IndexItem(string description)
        {
            for (int i = 0; i < ItemQuantity; i++)
            {
                if (items[i].Description == description.ToUpper())
                    return i;
            }

            throw new NotInShopException(description);
        }

        public string FindItemNumber(string description)
        {
            int index = this.IndexItem(description);

            return items[index].ItemNumber;
        }

        public void Sell(string description, int quantity, Order order)
        {
            int index = this.IndexItem(description);

            if (items[index].Quantity >= quantity)
            {
                items[index].Quantity -= quantity;              // 更新仓库状态
                order.AddOrderItem(items[index], quantity);               // 向order中添加一条消费明细
            }
            else
            {
                items.RemoveAt(index);
                itemQuantity--;
                throw new SoldOutException(description, items[index].Quantity);
            }
        }

        // 取消购买某一件商品，这里只是提供了这一功能，在Program中并未测试
        public void UnSell(string description, Order order)
        {
            order.RemoveOrderItem(description);
            int itemIndex = IndexItem(description);          // 在商店中的索引
            int itemIndexInOrder = order.FindIndexOfOrderItem(description);                //在明细中的索引
            items[itemIndex].Quantity += order.items[itemIndexInOrder].Quantity;
        }

        public override string ToString()
        {
            string result = "";
            foreach (Item item in items)
            {
                result += item;
            }
            return result;
        }

        public int ItemQuantity
        {
            get => itemQuantity;
        }
        int itemQuantity = 0;
    }
}
