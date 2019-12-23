using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.Infrastructure.Commands.Order;
using SimpleApi.Infrastructure.Services;

namespace SimpleApi.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class OrdersController : ApiControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailsService _orderDetailsService;
        public OrdersController(IOrderService orderService, IOrderDetailsService orderDetailsService)
        {
            _orderService = orderService;
            _orderDetailsService = orderDetailsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        => Json(await _orderService.BrowseAsync(UserId));

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

        [HttpGet("{orderId}/deatails")]
        public async Task<IActionResult> OrderDetailsGet(Guid orderId)
        {
            var order = await _orderDetailsService.BrowseAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }

            return Json(order);
        }

        [HttpPost("create")]

        public async Task<IActionResult> Post([FromBody]CreateOrder command)
        {
            command.OrderId = Guid.NewGuid();
            command.UserId = UserId;
           await _orderService.CreateAsync(command.OrderId, command.UserId, command.Products);
            await _orderDetailsService.AddAsync(command.Products.ToList());
            return Created($"orders/{command.OrderId}", null);
        }
       [HttpDelete("{orderId}")]
       public async Task<IActionResult> Delete(Guid orderId)
        {
            await _orderService.DeleteAsync(orderId);
            await _orderDetailsService.DeleteAsync(orderId);
            return NoContent();
        }


    }
}