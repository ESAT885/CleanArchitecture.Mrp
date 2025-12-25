using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Mrp.Application.Features.Auth.Commands.Login
{
    public sealed record LoginCommand(
      LoginRequestDto Request
  ) : IRequest<LoginResponseDto?>;
}
