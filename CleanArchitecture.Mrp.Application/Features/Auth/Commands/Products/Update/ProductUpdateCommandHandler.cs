

using AutoMapper;
using CleanArchitecture.Mrp.Application.Abstractions.Repositories;
using CleanArchitecture.Mrp.Application.DTOs.Products;
using MediatR;

namespace CleanArchitecture.Mrp.Application.Features.Auth.Commands.Products.Update
{
    public class ProductUpdateCommandHandler(IProductRepository userRepository, IMapper mapper) : IRequestHandler<ProductUpdateCommand, ProductDto?>
    {
     


        public async Task<ProductDto?> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Domain.Models.Entities.Product>(request.Request);
            await userRepository.CreateProduct(product);
            var productDto = mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}
