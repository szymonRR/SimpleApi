using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApi.Infrastructure.Commands.Products
{
   public class AddProduct
    {
        
        public string Name { get;  set; }
        public string Description { get;  set; }
        public decimal Price { get;  set; }
    }
}
