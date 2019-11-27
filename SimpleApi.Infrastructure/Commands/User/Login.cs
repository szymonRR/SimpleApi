using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApi.Infrastructure.Commands.User
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
