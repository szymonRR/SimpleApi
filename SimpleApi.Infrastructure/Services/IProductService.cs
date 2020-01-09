using SimpleApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Infrastructure.Services
{
   public interface IProductService
    {
        Task<Product> GetAsyc(Guid productId);
        Task AddAsync(string name,string description,decimal price);
        Task UpdateAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
