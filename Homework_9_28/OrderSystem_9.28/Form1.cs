using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderSystem;

namespace Homework_2020._4._10
{
    public partial class Form1 : Form
    {
        Shop myShop;

        public Form1()
        {
            InitializeComponent();

            myShop = new Shop();
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

            myShop.OrderService.AddOrder("jotaro");

            myShop.Sell("Apple", 3, myShop.OrderService.Orders[0]);
            myShop.Sell("Milk", 3, myShop.OrderService.Orders[0]);

            myShop.OrderService.AddOrder("josuke");
            myShop.Sell("Book", 1, myShop.OrderService.Orders[1]);

            myShop.OrderService.AddOrder("giorno");
            myShop.Sell("Cell phone", 1, myShop.OrderService.Orders[2]);
            myShop.Sell("computer", 2, myShop.OrderService.Orders[2]);
            myShop.Sell("shirt", 3, myShop.OrderService.Orders[2]);
            myShop.Sell("toilet paper", 13, myShop.OrderService.Orders[2]);

            waysComboBox.Items.Add("通过订单名检索");
            waysComboBox.Items.Add("通过商品名检索");
            waysComboBox.Items.Add("通过顾客名检索");

            orderBindingSource.DataSource = myShop.OrderService.Orders;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void BtnPurchase_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.items = myShop.Items;
            form2.myShop = this.myShop;

            form2.ShowDialog();
            orderBindingSource.ResetBindings(true);

            messageLabel.Text = "状态：添加订单成功";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Order thisOrder = (Order)orderBindingSource.Current;
            myShop.OrderService.DeleteOrder(thisOrder.OrderNumber);

            orderBindingSource.ResetBindings(true);

            messageLabel.Text = "状态：删除订单成功";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ordersSaveFileDialog.Filter = "XML文件|*.xml";
            ordersSaveFileDialog.DefaultExt = "xml";
            ordersSaveFileDialog.AddExtension = true;

            if (ordersSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                myShop.OrderService.Export(ordersSaveFileDialog.FileName);
            }

            messageLabel.Text = "状态：导出成功";
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ordersOpenFileDialog.Title = "导入订单";
            ordersOpenFileDialog.Filter = "XML文件|*.xml";

            ordersOpenFileDialog.FileName = "";
            ordersOpenFileDialog.DefaultExt = "xml";

            if (ordersOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                myShop.OrderService.Import(ordersOpenFileDialog.FileName);

                orderBindingSource.DataSource = myShop.OrderService.Orders;
                orderBindingSource.ResetBindings(true);
            }

            messageLabel.Text = "状态：导入成功";
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = myShop.OrderService.Orders;
            orderBindingSource.ResetBindings(true);

            messageLabel.Text = "状态：正常";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int sign = waysComboBox.SelectedIndex;

            string keyWords = keyWordsTextBox.Text;

            try
            {
                var selectedOrders = myShop.OrderService.FindOrder(keyWords, sign);

                List<Order> resultOrders = new List<Order>();
                foreach (var order in selectedOrders)
                {
                    resultOrders.Add(order);
                }

                orderBindingSource.DataSource = resultOrders;

                messageLabel.Text = "状态：正常";
            }
            catch (OrderNotExist)
            {
                messageLabel.Text = "状态：您查询的订单不存在";
            }
            catch (CustomerNotExistException)
            {
                messageLabel.Text = "状态：不存在该顾客的订单";
            }
            catch (OrderItemNotExist)
            {
                messageLabel.Text = "状态：没有订单中有该物品";
            }
            catch (InvalidSearchException)
            {
                messageLabel.Text = "状态：未选择检索方式";
            }
        }
    }
}
