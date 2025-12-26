using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Application.Abstractions.Repositories;
using CleanArchitecture.Mrp.Application.Abstractions.Security;
using CleanArchitecture.Mrp.Application.DTOs.Auth;
using CleanArchitecture.Mrp.Application.Exceptions;
using CleanArchitecture.Mrp.Application.Features.Auth.Commands.Login;
using CleanArchitecture.Mrp.Domain.Models.Entities;
using MediatR;

namespace CleanArchitecture.Mrp.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponseDto?>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public RefreshTokenCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<RefreshTokenResponseDto?> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var loginResponseDto = await _tokenService.ValidateRefreshTokenAsync(request.Request.UserId, request.Request.RefreshToken);
            if (loginResponseDto == null)
            {
                throw new UnauthorizedException("Invalid refresh token", "The provided refresh token is invalid or has expired.");
            }
            return new RefreshTokenResponseDto
            {
                AccessToken = loginResponseDto?.AccessToken!,
                RefreshToken = loginResponseDto?.RefreshToken!
            };
        }

     

    }
}
