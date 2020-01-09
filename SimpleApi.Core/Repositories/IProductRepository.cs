using SimpleApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Core.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsyc(Guid productId);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
