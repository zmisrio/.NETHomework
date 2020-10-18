using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Model
{
    [Serializable]
    public class OrderItem
    {
        public OrderItem()
        {
            UnitPrice = 0;
            Quantity = 0;
        }

        public OrderItem(Item item, int purchaseQuantity)
        {
            this.OrderItemNumber = NumberManager.GetOrderItemNumber();
            this.ItemNumber = item.ItemNumber;
            this.Description = item.Description;
            this.UnitPrice = item.Price;
            this.Quantity = purchaseQuantity;
        }

        [Key]
        public string OrderItemNumber { get; set; }
        public string ItemNumber { get; set; }

        [ForeignKey("ItemNumber")]
        public Item Item { get; set; }
        public string OrderNumber { get; set; }

        [ForeignKey("OrderNumber")]
        public Order Order { get; set; }
        public double UnitPrice { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null &&
                   OrderItemNumber == item.OrderItemNumber;
        }

        public override int GetHashCode()
        {
            return 743270795 + EqualityComparer<string>.Default.GetHashCode(OrderItemNumber);
        }

        public override string ToString()
        {
            return OrderItemNumber + "  " + Description + "  " + Quantity + "  " + UnitPrice + "\n";
        }
    }
}
