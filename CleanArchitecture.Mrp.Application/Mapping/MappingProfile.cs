
using AutoMapper;
using CleanArchitecture.Mrp.Application.DTOs.Auth;
using CleanArchitecture.Mrp.Application.DTOs.Products;
using CleanArchitecture.Mrp.Domain.Models.Entities;

namespace CleanArchitecture.Mrp.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
        }
    }
}
