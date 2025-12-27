using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Application.DTOs.Products;
using MediatR;

namespace CleanArchitecture.Mrp.Application.Features.Auth.Commands.Products.Update
{
    public sealed record ProductUpdateCommand(UpdateProductDto Request):IRequest<ProductDto?>
    {
    }
}
