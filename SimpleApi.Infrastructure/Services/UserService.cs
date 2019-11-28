using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SimpleApi.Core.Domain;
using SimpleApi.Core.Repositories;
using SimpleApi.Infrastructure.Dto;

namespace SimpleApi.Infrastructure.Services
{
   public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IJwtHandler jwtHandler, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
        }

        public async Task<AccountDto> GetAccountAsync(Guid userId)
        {
           var user = await _userRepository.GetAsync(userId);
            return _mapper.Map<AccountDto>(user);
        }

        public async Task<TokenDto> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);

            if (user == null)
            {
                throw new Exception($"Invalid credentials ");
            }

            if (user.Password != password)
            {
                throw new Exception($"Invalid credentials ");
            }
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            return new TokenDto
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = user.Role

            };
        }

        public async Task RegisterAasync(Guid userId, string email, string name, string password, string role = "user")
        {
            var user = await _userRepository.GetAsync(email);

            if (user != null)
            {
                throw new Exception($"User with this email: '{email}' alredy exist ");
            }

            user = new User(userId, role, name, email, password);
            await _userRepository.AddAsync(user);
        }
    }
}
