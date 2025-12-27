using CleanArchitecture.Mrp.Application.DTOs.Auth;
using CleanArchitecture.Mrp.Application.Exceptions;
using CleanArchitecture.Mrp.Application.Features.Auth.Commands.Login;
using CleanArchitecture.Mrp.Application.Features.Auth.Commands.RefreshToken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Mrp.Api.Controllers
{
  
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequestDto request)
        {
            var result = await _mediator.Send(new RefreshTokenCommand(request));
            if (result is null)
                throw new UnauthorizedException("Geçersiz yenileme belirteci", "Sağlanan yenileme belirteci geçersiz veya süresi dolmuş.");
            return Success<RefreshTokenResponseDto>(result);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var result = await _mediator.Send(new LoginCommand(request));
            if (result is null)
                throw new BusinessException("Geçersiz  kullanıcı ismi ve şifresi", "Geçersiz  kullanıcı ismi ve şifresi");
            return Success<LoginResponseDto>(result);
        }
        [Authorize]
        [HttpGet("AuthenticateOnlyEndpoint")]
        public IActionResult AuthenticateOnlyEndpoint()
        {
            var userName = User?.Identity?.Name;
            return Success(userName);
        }
    }
}
