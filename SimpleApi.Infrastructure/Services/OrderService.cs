using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleApi.Core.Domain;
using SimpleApi.Core.Repositories;
using SimpleApi.Infrastructure.Dto;

namespace SimpleApi.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDto>> BrowseAsync(Guid UserId)
        {
            var orders = await _orderRepository.BrowseAsync(UserId);
            return orders.Select(@order => new OrderDto
            {
                OrderId = @order.OrderId,
                UserId = @order.UserId,
                TotalPrice = @order.TotalPrice
            }) ;
        }

        public async Task CreateAsync(Guid OrderId, Guid UserId, IEnumerable<Product> products)
        {
           var order = new Order(OrderId, UserId, products);
            await _orderRepository.AddAsync(order);
        }

        public async Task DeleteAsync(Guid OrderId)
        {
            var order = await _orderRepository.GetAsync(OrderId);
            await _orderRepository.DeleteAsync(order);
        }

        public async Task<OrderDto> GetAsync(Guid Id)
        {
            var order = await _orderRepository.GetAsync(Id);
            return new OrderDto
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                TotalPrice = order.TotalPrice
            };
        }

        public async Task UpdateAsync(Guid OrderId)
        {
            var order = await _orderRepository.GetAsync(OrderId);
            await _orderRepository.UpdateAsync(order);
        }
    }
}
