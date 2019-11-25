using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimpleApi.Core.Domain
{
    public class Order : Entity
    {
        
        public Guid OrderId { get; protected set; }
        public Guid? UserId { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public IEnumerable<Product> Products { get; protected set; }
        public decimal TotalPrice { get; protected set; }

        protected Order()
        {

        }
        public Order(Guid orderId,Guid userId, IEnumerable<Product> products)
        {
            OrderId = orderId;
            UserId = userId;
            Products = products;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Total();
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
