using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    // 商品类，用来描述商店种的某种商品
    public class Item
    {
        public Item()
        {
            itemNumber = NumberManager.GetItemNumber();
        }

        public Item(string description, double price, int quantity)
        {
            itemNumber = NumberManager.GetItemNumber();
            this.Description = description.ToUpper();
            this.Price = price;
            this.Quantity = quantity;
        }

        string itemNumber;
        public string ItemNumber
        {
            get => itemNumber;
        }

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
                   itemNumber == item.itemNumber;
        }

        public override int GetHashCode()
        {
            return -1633458389 + EqualityComparer<string>.Default.GetHashCode(itemNumber);
        }
    }
}
