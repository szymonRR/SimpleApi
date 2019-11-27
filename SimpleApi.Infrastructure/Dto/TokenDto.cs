using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApi.Infrastructure.Dto
{
   public class TokenDto
    {
        public string Token { get; set; }
        public string Role { get; set; }
        public long Expires { get; set; }
    }
}
