using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    internal class ProductRepository:IProductRepository
    {
        private readonly IContext _context;
        public ProductRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product product)
        {
            var newProduct = _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return newProduct.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Products.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        
        public async Task<Product> UpdateAsync(Product product)
        {
            var update = _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return update.Entity;
        }
    }
}

