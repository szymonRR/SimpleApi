using SimpleApi.Core.Domain;
using SimpleApi.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Infrastructure.Services
{
   public interface IOrderService
    {
        Task<OrderDto> GetAsync(Guid Id);
        Task<IEnumerable<OrderDto>> BrowseAsync(Guid UserId);
        Task CreateAsync(Guid OrderId, Guid UserId, IEnumerable<OrderDetails> Products);
        Task UpdateAsync(Guid OrderId);
        Task DeleteAsync(Guid OrderId);



    }
}
