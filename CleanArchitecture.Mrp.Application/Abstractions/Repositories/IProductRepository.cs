using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Application.DTOs.Products;
using CleanArchitecture.Mrp.Domain.Models.Entities;

namespace CleanArchitecture.Mrp.Application.Abstractions.Repositories
{
    public interface IProductRepository
    {
        public Task<Product?> GetByIdAsync(Guid id);
        public Task<Product> CreateProductAsync(Product product);
        public  Task<Product> UpdateProductAsync(Product product);
    }
}
