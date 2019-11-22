using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimpleApi.Core.Domain
{
    public class Order : Entity
    {
        ISet<Product> _products = new HashSet<Product>();
        public Guid OrderId { get; protected set; }
        public Guid? UserId { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public IEnumerable<Product> Products => _products;
        public decimal TotalPrice { get; protected set; }

        protected Order()
        {

        }
        public Order(Guid orderId,Guid userId)
        {
            OrderId = orderId;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Total();
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
            Total();
            UpdatedAt = DateTime.UtcNow;
        }
        public void DeleteProduct(Product product)
        {
            _products.Remove(product);
            Total();
            UpdatedAt = DateTime.UtcNow;
        }
        public void Total()
        {
            decimal totalPrice=0;
            foreach(Product p in Products)
            {
                totalPrice += totalPrice;
            }
            TotalPrice = totalPrice;
        }
    }
}
