using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Model
{
    // 商品类，用来描述商店种的某种商品
    public class Item
    {
        public Item()
        {
            ItemNumber = NumberManager.GetItemNumber();
        }

        public Item(string description, double price, int quantity)
        {
            ItemNumber = NumberManager.GetItemNumber();
            this.Description = description.ToUpper();
            this.Price = price;
            this.Quantity = quantity;
        }

        [Key]
        public string ItemNumber { get; set; }

        public string ShopNumber { get; set; }
        [ForeignKey("ShopNumber")]
        public Shop Shop { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return ItemNumber + "  " + Description + "  $" + Price + "  " + Quantity + "\n";
        }

        public override bool Equals(object obj)
        {
            var item = obj as Item;
            return item != null &&
                   ItemNumber == item.ItemNumber;
        }

        public override int GetHashCode()
        {
            return -1633458389 + EqualityComparer<string>.Default.GetHashCode(ItemNumber);
        }
    }
}
