using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Application.Abstractions.Repositories;
using CleanArchitecture.Mrp.Application.DTOs.Products;
using CleanArchitecture.Mrp.Domain.Models.Entities;
using CleanArchitecture.Mrp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Mrp.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly UserDbContext _context;

        public ProductRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task<Product?> GetByIdAsync(Guid id)
           => await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
