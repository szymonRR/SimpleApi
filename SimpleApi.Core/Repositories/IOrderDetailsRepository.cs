using SimpleApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Core.Repositories
{
   public interface IOrderDetailsRepository
    {
        Task<IEnumerable<OrderDetails>> BrowseAsync(Guid orderId);
        Task AddAsync(List<OrderDetails> list);
        Task UpdateAsync(Guid orderId);
        Task DeleteAsync(Guid orderId);
    }
}
