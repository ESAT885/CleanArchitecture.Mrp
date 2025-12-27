using CleanArchitecture.Mrp.Application.DTOs.Auth;
using CleanArchitecture.Mrp.Application.DTOs.Users;
using CleanArchitecture.Mrp.Application.Features.Users.GetUsersWithFilter;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Mrp.Api.Controllers
{

    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] UserFilterDto filter)
        {
           

            var result = await _mediator.Send(
                new GetUsersQuery(filter));
            return Success<List<UserDto>>(result);
          
        }
    }
}
