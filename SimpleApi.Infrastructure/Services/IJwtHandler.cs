using SimpleApi.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApi.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}
