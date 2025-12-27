using CleanArchitecture.Mrp.Application.DTOs.Products;
using CleanArchitecture.Mrp.Application.DTOs.Users;
using CleanArchitecture.Mrp.Application.Features.Auth.Commands.Products;
using CleanArchitecture.Mrp.Application.Features.Auth.Commands.Products.Create;
using CleanArchitecture.Mrp.Application.Features.Users.GetUsersWithFilter;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Mrp.Api.Controllers
{
   
    public class ProductsController : BaseController
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] CreateProductDto createProductDto)
        {


            var result = await _mediator.Send(
                new ProductCreateCommand(createProductDto));
            return Success<ProductDto>(result);

        }
    }
}
