using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Mrp.Application.Abstractions.Repositories;
using CleanArchitecture.Mrp.Application.Abstractions.Security;
using CleanArchitecture.Mrp.Application.DTOs.Auth;
using CleanArchitecture.Mrp.Application.DTOs.Products;
using CleanArchitecture.Mrp.Application.Features.Auth.Commands.RefreshToken;
using MediatR;

namespace CleanArchitecture.Mrp.Application.Features.Auth.Commands.Products.Create
{
    public class ProductUpdateCommandHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<ProductCreateCommand, ProductDto?>
    {
     


        public async Task<ProductDto?> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Domain.Models.Entities.Product>(request.Request);
            await productRepository.CreateProductAsync(product);
            var productDto = mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}
