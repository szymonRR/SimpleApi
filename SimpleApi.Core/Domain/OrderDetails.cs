using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApi.Core.Domain
{
    public class OrderDetails : Entity
    {
        public Guid OrderId { get; protected set; }
        public Guid ProductId { get; protected set; }
        public int Amount { get; protected set; }
        public decimal Price { get; protected set; }

        public OrderDetails(Guid orderId, Guid productId, int amount, decimal price)
        {
            OrderId = orderId;
            ProductId = productId;
            Amount = amount;
            Price = price;
               
        }
    }

    
}
