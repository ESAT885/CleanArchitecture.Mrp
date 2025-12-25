using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Domain.Models.Entities;

namespace CleanArchitecture.Mrp.Application.Abstractions.Security
{
    public interface IPasswordHasher
    {
        bool Verify(User user, string password);
        string Hash(User user, string password);
    }
}
