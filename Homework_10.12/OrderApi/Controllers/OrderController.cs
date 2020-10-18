using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderApp.Model;

namespace OrderApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext orderDb;
        
        //构造函数把OrderContext 作为参数，Asp.net core 框架可以自动注入OrderContext对象
        public OrderController(OrderContext context)
        {
            this.orderDb = context;
        }

        // 通过ID查询
        // GET: api/order/idQuery?orderId=00000001
        [HttpGet("idQuery")]
        public ActionResult<Order> GetOrderByOrderId(string orderId)
        {
            var order = orderDb.Orders.FirstOrDefault(p=>p.OrderNumber==orderId);
            
            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // 通过顾客名查询
        // GET: api/order/customerNameQuery?customerName=zhong yuan
        [HttpGet("customerNameQuery")]
        public ActionResult<List<Order>> GetOrdersByCustomerName(string customerName)
        {
            var orders=orderDb.Orders.Where(p=>p.Customer.CustomerName==customerName.ToUpper()).ToList();

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // 通过物品名查询
        // GET: api/order/itemNameQuery?itemName=shirt
        [HttpGet("itemNameQuery")]
        public ActionResult<List<Order>> GetOrdersByItemName(string itemName)
        {
            var orderNumbers=orderDb.OrderItems.Where(p=>p.Description==itemName.ToUpper()).Select(p=>p.OrderNumber).ToList();
            var orders=orderDb.Orders.Where(p=>orderNumbers.Contains(p.OrderNumber)).ToList();

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // DELETE: api/order/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(string id)
        {
            try
            {
                var order = orderDb.Orders.FirstOrDefault(t => t.OrderNumber == id);
                if (order != null)
                {
                    orderDb.Remove(order);
                    orderDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

        // POST: api/order
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }

            return order;
        }

        // PUT: api/order/id
        [HttpPut("{id}")]
        public ActionResult<Order> PutOrder(string id, Order order)
        {
            if (id != order.OrderNumber)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDb.Entry(order).State = EntityState.Modified;
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }
    }
}
