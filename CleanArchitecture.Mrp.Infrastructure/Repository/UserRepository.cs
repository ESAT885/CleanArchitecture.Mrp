using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Application.Abstractions.Repositories;
using CleanArchitecture.Mrp.Domain.Models.Entities;
using CleanArchitecture.Mrp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Mrp.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public Task<User?> GetByUsernameAsync(string username)
            => _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

        public Task<User?> GetByIdAsync(Guid id)
            => _context.Users.FirstOrDefaultAsync(x=>x.Id==id);

        public Task<bool> ExistsAsync(string username)
            => _context.Users.AnyAsync(x => x.UserName == username);

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public Task<User?> GetByUserNameAsync(string userName)
             => _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        
    }
}
