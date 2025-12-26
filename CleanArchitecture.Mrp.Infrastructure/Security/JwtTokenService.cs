
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CleanArchitecture.Mrp.Application.Abstractions.Repositories;
using CleanArchitecture.Mrp.Application.Abstractions.Security;
using CleanArchitecture.Mrp.Domain.Models.Entities;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.Mrp.Application.DTOs.Auth;

namespace CleanArchitecture.Mrp.Infrastructure.Security
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public JwtTokenService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<LoginResponseDto> CreateTokenResponseAsync(User user)
        {
            var refreshToken = GenerateRefreshToken();
            user.RefreshTokenHash = TokenHasher.Hash(refreshToken);
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _userRepository.UpdateAsync(user);
             

            return new LoginResponseDto
            {
                UserId=user.Id,
                AccessToken = CreateJwt(user),
                RefreshToken = refreshToken
            };
        }

        public async Task<LoginResponseDto?> ValidateRefreshTokenAsync(Guid userId, string refreshToken)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                return null;

            if (TokenHasher.Hash(refreshToken) != user.RefreshTokenHash)
                return null;
              


            return new LoginResponseDto
            {
                UserId = user.Id,
                AccessToken = CreateJwt(user),
                RefreshToken = await GenerateAndSaveRefreshTokenAsync(user)
            };
        }
        private async Task<string> GenerateAndSaveRefreshTokenAsync(User user)
        {
            var refreshToken = GenerateRefreshToken();
            user.RefreshTokenHash = TokenHasher.Hash(refreshToken);
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
           await _userRepository.UpdateAsync(user);
            
            return refreshToken;
        }
        private string CreateJwt(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user?.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
              
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
               _configuration.GetValue<string>("AppSettings:Token")!
            ));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokendescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);


            return new JwtSecurityTokenHandler().WriteToken(tokendescriptor);
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
