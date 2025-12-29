

using AutoMapper;
using CleanArchitecture.Mrp.Application.Abstractions.Repositories;
using CleanArchitecture.Mrp.Application.DTOs.Products;
using CleanArchitecture.Mrp.Application.Exceptions;
using MediatR;

namespace CleanArchitecture.Mrp.Application.Features.Auth.Commands.Products.Update
{
    public class ProductUpdateCommandHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<ProductUpdateCommand, ProductDto?>
    {
     


        public async Task<ProductDto?> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Request.Id);
            if (product == null)
            {
                throw new NotFoundException($"Product with Id {request.Request.Id} not found.", $"Product with Id {request.Request.Id} not found.");
            }   
            product.Name = request.Request.Name;
            product.StockQuantity = request.Request.StockQuantity;
            await productRepository.UpdateProductAsync(product);
            var productDto = mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}
