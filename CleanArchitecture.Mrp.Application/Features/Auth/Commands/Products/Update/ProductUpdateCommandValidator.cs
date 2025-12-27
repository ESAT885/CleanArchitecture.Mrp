using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Application.Features.Auth.Commands.RefreshToken;
using FluentValidation;

namespace CleanArchitecture.Mrp.Application.Features.Auth.Commands.Products.Update
{
    public class ProductUpdateCommandValidator : AbstractValidator<ProductUpdateCommand>
    {
        public ProductUpdateCommandValidator()
        {
            RuleFor(p => p.Request.Name)
               .NotEmpty();
            RuleFor(p => p.Request.StockQuantity)
                .NotEmpty();
        }
    }
}
