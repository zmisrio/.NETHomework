using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace OrderSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            // 此程序只是检验了各种功能，并未设计用户交互界面
            Shop myShop = new Shop();
            myShop.AddItem("Apple", 3, 500);
            myShop.AddItem("Computer", 3000, 104);
            myShop.AddItem("Banana", 2, 9000);
            myShop.AddItem("Cell Phone", 8000, 40);
            myShop.AddItem("Bottle", 10, 300);
            myShop.AddItem("Milk", 5, 4000);
            myShop.AddItem("Toilet Paper", 1, 50000);
            myShop.AddItem("Mask", 1, 4000);
            myShop.AddItem("Pencil", 0.3, 5000);
            myShop.AddItem("Book", 2, 4000);
            myShop.AddItem("Shirt", 20, 360);
            // 向shop中加入一些货物,参数分别为货物名称、加格、数量


            Console.WriteLine("我的商店:");
            Console.Write(myShop);
            Console.WriteLine("--------------------------------------");

            try
            {
                //创建订单
                Console.WriteLine("您要制定多少个订单？");
                int orderAmount = int.Parse(Console.ReadLine());

                for (int i = 0; i < orderAmount; i++)
                {
                    Console.WriteLine("请输入您第" + (i + 1) + "个订单的顾客姓名：");
                    Customer customer = new Customer(Console.ReadLine());
                    myShop.OrderService.AddOrder(customer);

                    Console.WriteLine("您需要买多少东西？");
                    int itemAmount = int.Parse(Console.ReadLine());
                    for (int j = 0; j < itemAmount; j++)
                    {
                        Console.WriteLine("您需要购买的第" + (j + 1) + "商品名称是：");
                        string thisItem = Console.ReadLine();
                        Console.WriteLine("您需要购买多少件" + thisItem + "：");
                        int purchaseAmount = int.Parse(Console.ReadLine());
                        myShop.Sell(thisItem, purchaseAmount, myShop.OrderService.orders[i]);
                    }
                    Console.WriteLine("-----------------------------");
                    Thread.Sleep(1000);
                }

                string xmlFilePath = "TestExport.xml";
                myShop.OrderService.Export(xmlFilePath);
                myShop.OrderService.PrintOrders();

                // 检索功能
                Console.WriteLine("请输入您需要的检索方式（0. 通过订单号；1. 通过物品名； 2. 通过顾客姓名）：");
                int searchWay = int.Parse(Console.ReadLine());
                Console.WriteLine("请输入您的检索关键字：");
                string keyWord = Console.ReadLine();
                var results = myShop.OrderService.FindOrder(keyWord, searchWay);

                Console.WriteLine("以下是检索结果：");
                foreach (var result in results)
                {
                    Console.WriteLine("");
                    Console.Write(result);
                }

                // 排序功能
                Console.WriteLine("按下回车键以继续");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {
                    Console.WriteLine("请按下回车键以继续");
                }
                Console.WriteLine("\n根据购买商品类别的数量对所有订单进行排序：");
                myShop.OrderService.SortOrders();

                myShop.OrderService.PrintOrders();

                // 由于添加订单功能只能通过SELL动作完成，故不给管理员额外添加增加订单功能
                // 由于修改订单功能分别通过myShop类里的Sell和UnSell方法完成，故不给管理员额外添加修改订单功能
                // 删除订单功能
                Console.WriteLine("根据订单号删除订单，请输入所需删除的订单号");
                string orderNumber = Console.ReadLine();
                myShop.OrderService.DeleteOrder(orderNumber);
                myShop.OrderService.PrintOrders();

                string importXMLFilePath = "TestForImport.xml";
                myShop.OrderService.Import(importXMLFilePath);
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Here is a test for import:");
                myShop.OrderService.PrintOrders();

            }
            catch (FormatException)
            {
                Console.WriteLine("您的输入有误！");
            }
            catch (NotInShopException e)             // 购买的物品商店中没有
            {
                Console.WriteLine("抱歉，我们商店中没有" + e.Description);
            }
            catch (SoldOutException e)               // 购买的商品储存中不足
            {
                Console.WriteLine("抱歉，我们商店中只剩下" + e.ItemLeftAmout + "件" + e.Description + "了。");
            }
            catch (OrderNotExist e)                  // 查询订单号不存在
            {
                Console.WriteLine("订单" + e.OrderNumber + "不存在");
            }
            catch (OrderItemNotExist e)              // 查询的物品名称不在订单中
            {
                Console.WriteLine("订单中没有物品" + e.Description);
            }
            catch (CustomerNotExistException e)      // 查询不到该顾客的订单
            {
                Console.WriteLine("没有顾客" + e.CustomerName + "的订单");
            }
            catch (InvalidSearchException)
            {
                Console.WriteLine("您输入的查询方式有误！");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("未读取到文件！");
            }

        }
    }
}
