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
        private readonly ISet<Order> _orders = new HashSet<Order> {


            new Order(Guid.NewGuid(),Guid.NewGuid(), new List<Product>{ new Product(Guid.NewGuid(),"Pralka","duza",1234) })
        
        };
        public async Task AddAsync(Order order)
        {
            _orders.Add(order);
            await Task.CompletedTask;
        }

       

        public async Task DeleteAsync(Order order)
        {
            _orders.Remove(order);
            await Task.CompletedTask;
        }

        public async Task<Order> GetAsync(Guid id)
        => await Task.FromResult(_orders.SingleOrDefault(x => x.Id == id));

        public async Task UpdateAsync(Order order)
        {
            await Task.CompletedTask;
        }

       public async Task<IEnumerable<Order>> BrowseAsync(Guid userId)
        {
            var orders = _orders.AsEnumerable();
            
            
                orders = orders.Where(x => x.UserId == userId);
            

            return await Task.FromResult(orders);
        }
    }
}
