using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Application.Abstractions.Security;
using CleanArchitecture.Mrp.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Mrp.Infrastructure.Security
{
    public class PasswordHasherAdapter : IPasswordHasher
    {
        private readonly PasswordHasher<User> _hasher = new();

        public bool Verify(User user, string password)
            => _hasher.VerifyHashedPassword(user, user.PasswordHash, password)
               != PasswordVerificationResult.Failed;

        public string Hash(User user, string password)
            => _hasher.HashPassword(user, password);
    }
}
