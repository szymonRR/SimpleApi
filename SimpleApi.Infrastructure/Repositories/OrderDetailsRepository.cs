using SimpleApi.Core.Domain;
using SimpleApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Infrastructure.Repositories
{
   public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly AppDbContext _dbContext;
        public OrderDetailsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<OrderDetails>> BrowseAsync(Guid orderId)
        {
            var ordersDetails = _dbContext.OrderDetailItems.Where(x => x.OrderId == orderId).ToList();


            return await Task.FromResult(ordersDetails);
        }

        public async Task AddAsync(List<OrderDetails> list)
        {
            

            _dbContext.OrderDetailItems.AddRange(list);
            
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid orderId)
        {
            _dbContext.OrderDetailItems.RemoveRange(_dbContext.OrderDetailItems.Where(x => x.OrderId == orderId));
            _dbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Guid orderId)
        {
            await Task.CompletedTask;
        }
    }
}
