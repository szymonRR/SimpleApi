using SimpleApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Core.Repositories
{
    public class IOrderRepository
    {
        Task<Order> GetAsync(Guid id);
        Task<Order> GetAsync(Guid userId);
        Task<Order> BrowseAsync(Guid userId);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);
    }
}
