using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.Infrastructure.Commands.Order;
using SimpleApi.Infrastructure.Services;

namespace SimpleApi.Api.Controllers
{
    [Route("[controller]")]
    public class OrdersController : ApiControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid userId)
        {
            var orders = await _orderService.BrowseAsync(userId);
            return Json(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> OrderGet(Guid orderId)
        {
            var order = await _orderService.GetAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }

            return Json(order);
        }
        
        [HttpPost]

        public async Task<IActionResult> Post([FromBody]CreateOrder command)
        {
            command.OrderId = Guid.NewGuid();
            command.UserId = UserId;
           await _orderService.CreateAsync(command.OrderId, command.UserId, command.Products); //To Do Products from card?
            return Created($"orders/{command.OrderId}", null);
        }
       [HttpDelete("{orderId}")]
       public async Task<IActionResult> Delete(Guid orderId)
        {
            await _orderService.DeleteAsync(orderId);
            return NoContent();
        }


    }
}