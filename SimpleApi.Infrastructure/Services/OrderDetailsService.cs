using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SimpleApi.Core.Domain;
using SimpleApi.Core.Repositories;

namespace SimpleApi.Infrastructure.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {

        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IMapper _mapper;
        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetails>> BrowseAsync(Guid orderId)
        {
            var details = await _orderDetailsRepository.BrowseAsync(orderId);
            return details;

        }
        public async Task AddAsync(List<OrderDetails> list)
        {
           await _orderDetailsRepository.AddAsync(list);
        }

      

        public async Task DeleteAsync(Guid orderId)
        {
            await _orderDetailsRepository.DeleteAsync(orderId);
        }

        public async Task UpdateAsync(Guid orderId)
        {
            await Task.CompletedTask;
        }
    }
}
