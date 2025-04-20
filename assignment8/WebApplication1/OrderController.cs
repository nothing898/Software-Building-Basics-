using Homework1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OrderWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext _context;
        public OrdersController(OrderDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _context.Orders.Include(o => o.OrderDetailsList).ToListAsync();
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.Include(o => o.OrderDetailsList)
                                             .FirstOrDefaultAsync(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/Orders
        // 创建新的订单
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest();

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // 返回201状态，并在Location中返回新资源的URI
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        // PUT: api/Orders/5
        // 更新订单信息
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            if (id != order.OrderId)
                return BadRequest();

            // 查询已有订单（包含订单明细）
            var existingOrder = await _context.Orders.Include(o => o.OrderDetailsList)
                                                     .FirstOrDefaultAsync(o => o.OrderId == id);
            if (existingOrder == null)
                return NotFound();

            // 更新属性（例如客户名称）
            existingOrder.Customer = order.Customer;

            // 此处简单处理：清空原有明细并添加新的明细
            existingOrder.OrderDetailsList.Clear();
            if (order.OrderDetailsList != null)
            {
                foreach (var detail in order.OrderDetailsList)
                {
                    // 可以进一步处理（如判断是否存在冲突等）
                    existingOrder.OrderDetailsList.Add(detail);
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.Include(o => o.OrderDetailsList)
                                             .FirstOrDefaultAsync(o => o.OrderId == id);
            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
