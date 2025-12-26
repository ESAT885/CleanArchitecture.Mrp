using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Application.Features.Auth.Commands.Login;
using FluentValidation;

namespace CleanArchitecture.Mrp.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(p => p.Request.UserId)
               .NotEmpty();
            RuleFor(p => p.Request.RefreshToken)
                .NotEmpty();
        }
    }
}
