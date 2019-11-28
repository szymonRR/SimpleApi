using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SimpleApi.Core.Domain;
using SimpleApi.Core.Repositories;
using SimpleApi.Infrastructure.Dto;

namespace SimpleApi.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> BrowseAsync(Guid UserId)
        {
            var orders = await _orderRepository.BrowseAsync(UserId);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
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
            return _mapper.Map<OrderDto>(order);
        }

        public async Task UpdateAsync(Guid OrderId)
        {
            var order = await _orderRepository.GetAsync(OrderId);
            await _orderRepository.UpdateAsync(order);
        }
    }
}
