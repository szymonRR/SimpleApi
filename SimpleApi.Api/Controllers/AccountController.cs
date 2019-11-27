using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.Infrastructure.Commands.User;
using SimpleApi.Infrastructure.Services;

namespace SimpleApi.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {

        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public AccountController(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        => Json(await _userService.GetAccountAsync(UserId));

        [HttpGet("orders")]
        [Authorize]
        public async Task<IActionResult> GetOrders()
        => Json(await _orderService.GetAsync(UserId));

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]RegisterUser command)
        {
            await _userService.RegisterAasync(Guid.NewGuid(), command.Email,
              command.Name, command.Password, command.Role);
            return Created("/account", null);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
        => Json(await _userService.LoginAsync(command.Email, command.Password));
    }
}