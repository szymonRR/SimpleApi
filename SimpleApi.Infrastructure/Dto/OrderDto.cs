using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApi.Infrastructure.Dto
{
   public class OrderDto
    {
        public Guid OrderId { get;  set; }
        public Guid? UserId { get;  set; }
        public decimal TotalPrice { get; set; }
    }
}
