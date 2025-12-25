using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Domain.Models.Entities;

namespace CleanArchitecture.Mrp.Application.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUserNameAsync(string userName);
        Task<User?> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(string userName);
        Task UpdateAsync(User user);
        Task AddAsync(User user);
    }
}
