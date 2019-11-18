using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApi.Core.Domain
{
    public class Product :Entity
    {
        public Guid ProductId { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Price { get; protected set; }


        public Product(Guid productId,string name, string description,decimal price)
        {
            ProductId = productId;
            SetName(name);
            Description = description;
            Price = price;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"Product can not have an empty name.");
            }
            Name = name;
        }
        public void SetPrice(decimal price)
        {
            if (price < 0)
            {
                throw new Exception($"Product can not have an empty price.");
            }
            Price = price;
        }
    }
}
