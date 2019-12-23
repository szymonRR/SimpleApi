using SimpleApi.Core.Domain;
using SimpleApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SimpleApi.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        
        private readonly AppDbContext _dbContext;
        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Order order)
        {
            _dbContext.OrderItems.Add(order);
            _dbContext.SaveChanges();
            await Task.CompletedTask;
        }

       

        public async Task DeleteAsync(Order order)
        {
            _dbContext.OrderItems.Remove(order);
            _dbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task<Order> GetAsync(Guid id)
        => await Task.FromResult(_dbContext.OrderItems.Where(x => x.OrderId == id).SingleOrDefault());

        public async Task UpdateAsync(Order order)
        {
            await Task.CompletedTask;
        }

       public async Task<IEnumerable<Order>> BrowseAsync(Guid userId)
        {



           var orders = _dbContext.OrderItems.Where(x => x.UserId == userId).ToList();
            

            return await Task.FromResult(orders);
        }
    }
}
