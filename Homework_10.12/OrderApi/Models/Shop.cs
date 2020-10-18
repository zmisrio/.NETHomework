using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Model
{
    // 商店类
    public class Shop
    {
        [Key]
        public string ShopNumber { get; set; }
        public List<Item> Items { get; set; }                   // 商店中已有的货物，可以理解为仓库

        public OrderService OrderService { get; set; }

        public int ItemQuantity
        {
            get => itemQuantity;
        }
        int itemQuantity = 0;

        public Shop()
        {
            ShopNumber = NumberManager.GetShopNumber();
            Items = new List<Item>();
            OrderService = new OrderService();
        }

        public void AddItem(string description, double price, int quantity)
        {
            Item item = new Item(description, price, quantity);
            Items.Add(item);
            itemQuantity++;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
            itemQuantity++;
        }

        // 根据商品名称寻找商品的索引
        public int IndexItem(string description)
        {
            for (int i = 0; i <ItemQuantity;i++)
            {
                if (Items[i].Description == description.ToUpper())
                    return i;
            }

            throw new NotInShopException(description);
        }

        public string FindItemNumber(string description)
        {
            int index = this.IndexItem(description);

            return Items[index].ItemNumber;
        }

        public void Sell(string description, int quantity, Order order)
        {
            int index = this.IndexItem(description);

            if (Items[index].Quantity >= quantity)
            {
                Items[index].Quantity -= quantity;                        // 更新仓库状态
                order.AddOrderItem(Items[index], quantity);               // 向order中添加一条消费明细
            }   
            else
            {
                Items.RemoveAt(index);
                itemQuantity--;
                throw new SoldOutException(description, Items[index].Quantity);
            }
        }

        // 取消购买某一件商品，这里只是提供了这一功能，在Program中并未测试
        public void UnSell(string description,Order order)
        {
            order.RemoveOrderItem(description);
            int itemIndex = IndexItem(description);                                        // 在商店中的索引
            int itemIndexInOrder = order.FindIndexOfOrderItem(description);                // 在明细中的索引
            Items[itemIndex].Quantity += order.Items[itemIndexInOrder].Quantity;
        }

        public override string ToString()
        {
            string result = "";
            foreach(Item item in Items)
            {
                result += item;
            }
            return result;
        }
    }
}
