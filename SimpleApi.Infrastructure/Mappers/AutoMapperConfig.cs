using AutoMapper;
using SimpleApi.Core.Domain;
using SimpleApi.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApi.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Order, OrderDto>();
                    cfg.CreateMap<User, AccountDto>();


                }).CreateMapper();
    }
}
