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
    [Serializable]
    public class Order
    {
        [Key]
        public string OrderNumber { get; set; }
        public string CustomerNumber { get; set; }

        [ForeignKey("CustomerNumber")]
        public Customer Customer { get; set; }
        public string CustomerName { get => Customer.CustomerName; }

        public string OrderServiceNumber { get; set; }
        [ForeignKey("OrderServiceNumber")]
        public OrderService OrderService { get; set; }

        public List<OrderItem> Items { get; set; }
        public int OrderItemAmount { get => Items.ToArray().Length; }
        public double TotalPrice
        {
            get
            {
                double totalPrice = 0;
                foreach(OrderItem item in Items)
                {
                    totalPrice += item.UnitPrice * item.Quantity;
                }

                return totalPrice;
            }
        }

        public Order()
        {
            OrderNumber = NumberManager.GetOrderNumber();
            Customer = new Customer();
            Items = new List<OrderItem>();
        }

        public Order(Customer customer)
        {
            OrderNumber = NumberManager.GetOrderNumber();
            this.Customer = customer;
            Items = new List<OrderItem>();
        }

        // 通过某一物品的名字，判断是否在明细里
        public bool Contains(string itemName)
        {
            itemName = itemName.ToUpper();
            foreach(OrderItem item in Items)
            {
                if (item.Description == itemName) 
                    return true;
            }
            return false;
        }

        // 根据商品名称查询在商品明细中的索引
        public int FindIndexOfOrderItem(string description)
        {
            description = description.ToUpper();
            int i = 0;
            foreach(OrderItem item in Items)
            {
                if (item.Description == description)
                    return i;
                i++;
            }

            throw new OrderItemNotExist(description);
        }

        public void AddOrderItem(Item item,int purchaseQuantity)
        {
            // 如果该件物品已在消费明细中存在，就只是在该条明细后添加数量
            if(Contains(item.Description))
            {
                int itemIndex = FindIndexOfOrderItem(item.Description);
                Items[itemIndex].Quantity += purchaseQuantity;
            }
            // 否则新加入一条消费明细
            else
            {
                Items.Add(new OrderItem(item, purchaseQuantity));
            }
        }

        public void RemoveOrderItem(string description)
        {
            description = description.ToUpper();
            Items.RemoveAt(FindIndexOfOrderItem(description));
        }

        public override string ToString()
        {
            string result = "-----------------------------\n";
            result += "-----------------------------\n";
            result += "OrderNumber: " + OrderNumber + "\n";
            result += "Customer: " + Customer + "\n";
            result += "-----------------------------\n";
            result += "Item NO.  Description  Quantity  UnitPrice\n";
            foreach (OrderItem orderItem in Items)
            {
                result += orderItem;
            }
            result += "-----------------------------\n";
            result += "Item Amount:c" + this.OrderItemAmount + "\n";
            result += "Total Price: $" + this.TotalPrice + "\n";
            result += "-----------------------------\n";
            result += "-----------------------------\n";

            return result;
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   OrderNumber == order.OrderNumber;
        }

        public override int GetHashCode()
        {
            return -247030458 + EqualityComparer<string>.Default.GetHashCode(OrderNumber);
        }
    }
}
