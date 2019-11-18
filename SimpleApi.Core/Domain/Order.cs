using System;
using System.Collections.Generic;
using System.Text;

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

        protected Order()
        {

        }
        public Order(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
