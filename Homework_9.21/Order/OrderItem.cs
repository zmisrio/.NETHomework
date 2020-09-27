using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
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
            this.ItemNumber = item.ItemNumber;
            this.Description = item.Description;
            this.UnitPrice = item.Price;
            this.Quantity = purchaseQuantity;
        }

        public string ItemNumber { get; set; }
        public double UnitPrice { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null &&
                   ItemNumber == item.ItemNumber;
        }

        public override int GetHashCode()
        {
            return 743270795 + EqualityComparer<string>.Default.GetHashCode(ItemNumber);
        }

        public override string ToString()
        {
            return ItemNumber + "  " + Description + "  " + Quantity + "  " + UnitPrice + "\n";
        }
    }
}
