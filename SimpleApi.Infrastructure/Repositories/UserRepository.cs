using Microsoft.EntityFrameworkCore;
using SimpleApi.Core.Domain;
using SimpleApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

       //private static readonly ISet<User> _users = new HashSet<User>();
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(User user)
        {
            
            _dbContext.UsersItems.Add(user);
            _dbContext.SaveChanges();
            await Task.CompletedTask;

        }

        public async Task DeleteAsync(User user)
        {
            _dbContext.UsersItems.Remove(user);
            _dbContext.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(Guid id)
        => await Task.FromResult(_dbContext.UsersItems.Where(x => x.Id == id).SingleOrDefault());

        public async Task<User> GetAsync(string email)
        => await Task.FromResult(_dbContext.UsersItems.Where(x => x.Email == email.ToLowerInvariant()).Single());

        public async Task UpdateAsync(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
            await Task.CompletedTask;
        }
    }
}
