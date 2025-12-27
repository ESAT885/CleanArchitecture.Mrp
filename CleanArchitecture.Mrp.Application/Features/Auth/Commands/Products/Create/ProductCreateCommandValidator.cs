using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Application.Features.Auth.Commands.RefreshToken;
using FluentValidation;

namespace CleanArchitecture.Mrp.Application.Features.Auth.Commands.Products.Create
{
    public class ProductCreateCommandValidator : AbstractValidator<ProductCreateCommand>
    {
        public ProductCreateCommandValidator()
        {
            RuleFor(p => p.Request.Name)
               .NotEmpty();
            RuleFor(p => p.Request.StockQuantity)
                .NotEmpty();
        }
    }
}
