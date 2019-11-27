using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApi.Infrastructure.Commands.User
{
   public class RegisterUser
    {
        public Guid UserId { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
