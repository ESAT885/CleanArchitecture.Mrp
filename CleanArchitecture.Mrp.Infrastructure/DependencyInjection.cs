using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Application.Abstractions.Security;
using CleanArchitecture.Mrp.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Mrp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
   this IServiceCollection services,
   IConfiguration configuration)
        {
            services.AddScoped<IPasswordHasher, PasswordHasherAdapter>();
            services.AddScoped<ITokenService, JwtTokenService>();
            // Diğer servisler
            // IUserRepository, DbContext vs.

            return services;
        }
    }

}
