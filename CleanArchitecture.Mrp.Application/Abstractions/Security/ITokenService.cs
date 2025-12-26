using CleanArchitecture.Mrp.Application.DTOs.Auth;
using CleanArchitecture.Mrp.Domain.Models.Entities;

namespace CleanArchitecture.Mrp.Application.Abstractions.Security
{
    public interface ITokenService
    {
        public  Task<LoginResponseDto> CreateTokenResponseAsync(User user);
        public  Task<User?> ValidateRefreshTokenAsync(Guid userId, string refreshToken);
    }
}
