using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleApi.Core.Domain;
using SimpleApi.Core.Repositories;

namespace SimpleApi.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetAsyc(Guid productId)
        => await _productRepository.GetAsyc(productId);

        public async Task AddAsync(string name, string description, decimal price)
        {
            var product = new Product(Guid.NewGuid(),name,description,price);
            await _productRepository.AddAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _productRepository.GetAsyc(id);
            await _productRepository.DeleteAsync(product);
        }

       

        public async Task UpdateAsync(Guid id)
        {
            var product = await _productRepository.GetAsyc(id);
            await _productRepository.UpdateAsync(product);
        }
    }
}
