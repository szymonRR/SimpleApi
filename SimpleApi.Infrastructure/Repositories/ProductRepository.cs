using SimpleApi.Core.Domain;
using SimpleApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {


        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetAsyc(Guid productId)
        => await Task.FromResult(_context.ProductItems.Where(x => x.ProductId == productId).SingleOrDefault());
        public async Task AddAsync(Product product)
        {
            _context.ProductItems.Add(product);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Product product)
        {
            _context.ProductItems.Remove(product);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

       

        public async Task UpdateAsync(Product product)
        {
            await Task.CompletedTask;
        }
    }
}
