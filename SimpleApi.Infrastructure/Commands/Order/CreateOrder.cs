using SimpleApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApi.Infrastructure.Commands.Order
{
   public class CreateOrder
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<Product> Products { get;  set; }
    }
}
