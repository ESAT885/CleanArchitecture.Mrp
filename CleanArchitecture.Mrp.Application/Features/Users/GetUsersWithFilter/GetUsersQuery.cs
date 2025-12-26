using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Application.DTOs.Users;
using MediatR;

namespace CleanArchitecture.Mrp.Application.Features.Users.GetUsersWithFilter
{
    public record GetUsersQuery(UserFilterDto Filter)
    : IRequest<List<UserDto>>;
}
