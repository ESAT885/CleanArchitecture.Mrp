using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Application.DTOs.Auth;
using MediatR;

namespace CleanArchitecture.Mrp.Application.Features.Auth.Commands.RefreshToken
{
    public sealed record RefreshTokenCommand(RefreshTokenRequestDto Request):IRequest<RefreshTokenResponseDto?>
    {
    }
}
