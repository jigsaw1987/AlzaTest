using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Product?>> GetAll() => await _context.Products.ToListAsync();

        public async Task<Product?> GetById(int id) => await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
 
        public async Task<Product?> UpdateDescription(int id, string description)
        {
            var product = GetById(id);

            if (product.Result == null) 
                return product.Result;

            product.Result.Description = description;
            await _context.SaveChangesAsync();

            return product.Result;
        }
    }
}
