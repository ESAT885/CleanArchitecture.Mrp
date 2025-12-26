using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitecture.Mrp.Application.Features.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(p => p.Request.UserName)
                .MinimumLength(3)
                .WithMessage("Kullanıcı adı ya da mail bilgisi en az 3 karakter olmalıdır");
            RuleFor(p => p.Request.Password)
                .MinimumLength(6)
                .WithMessage("Şifre en az 1 karakter olmalıdır");
        }
    }
}
