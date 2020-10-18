using Microsoft.EntityFrameworkCore;
using System.Text;
using System;

namespace OrderApp.Model
{
    public class OrderContext:DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options){
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated(); //自动建库建表

            DbInitialize();
        }

        private void DbInitialize()
        {
            Shop myShop = new Shop();
            Item apple = new Item("Apple", 3, 500);
            Item computer = new Item("Computer", 3000, 104);
            Item banana = new Item("Banana", 2, 9000);
            Item cellPhone = new Item("Cell Phone", 8000, 40);
            Item bottle = new Item("Bottle", 10, 300);
            Item milk = new Item("Milk", 5, 4000);
            Item toiletPaper = new Item("Toilet Paper", 1, 50000);
            Item mask = new Item("Mask", 1, 4000);
            Item pencil = new Item("Pencil", 0.3, 5000);
            Item book = new Item("Book", 2, 4000);
            Item shirt = new Item("Shirt", 20, 360);

            myShop.AddItem(apple);
            myShop.AddItem(computer);
            myShop.AddItem(banana);
            myShop.AddItem(cellPhone);
            myShop.AddItem(bottle);
            myShop.AddItem(milk);
            myShop.AddItem(toiletPaper);
            myShop.AddItem(mask);
            myShop.AddItem(pencil);
            myShop.AddItem(book);
            myShop.AddItem(shirt);

            myShop.OrderService.AddOrder("zhong yuan");

            myShop.Sell("Apple", 3, myShop.OrderService.Orders[0]);
            myShop.Sell("Milk", 3, myShop.OrderService.Orders[0]);

            myShop.OrderService.AddOrder("zhang qianshu");
            myShop.Sell("Book", 1, myShop.OrderService.Orders[1]);
            myShop.Sell("shirt", 1, myShop.OrderService.Orders[1]);

            myShop.OrderService.AddOrder("meng suhua");
            myShop.Sell("Cell phone", 1, myShop.OrderService.Orders[2]);
            myShop.Sell("computer", 2, myShop.OrderService.Orders[2]);
            myShop.Sell("shirt", 3, myShop.OrderService.Orders[2]);
            myShop.Sell("toilet paper", 13, myShop.OrderService.Orders[2]);

            this.Shops.Add(myShop);
            this.SaveChanges();
        }

        
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderService> OrderServices { get; set; }
    }
}
