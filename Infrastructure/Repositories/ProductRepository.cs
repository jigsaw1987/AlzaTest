using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Repository for product.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Db context.</param>
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all available products from database.
        /// </summary>
        /// <returns>Collection of product or null, if wasn't found.</returns>
        public async Task<ICollection<Product?>> GetAll() => await _context.Products.ToListAsync();

        /// <summary>
        /// Get one product from database depends on unique id.
        /// </summary>
        /// <param name="id">Unique id.</param>
        /// <returns>Product or null, if wasn't found.</returns>
        public async Task<Product?> GetById(int id) => await _context.Products.SingleOrDefaultAsync(p => p.Id == id);

        /// <summary>
        /// Get products with offset and maximum limit. Use for pagination.
        /// </summary>
        /// <param name="offset">Offset.</param>
        /// <param name="limit">Maximum limit of product to get.</param>
        /// <returns>Collection of <see cref="Product"/></returns>
        public async Task<ICollection<Product?>> GetAll(int offset, int limit)
        {
            if(limit == 0) 
                limit = 10;

            return await _context.Products.Skip(offset).Take(limit).ToListAsync();
        }

        /// <summary>
        /// Update description of product.
        /// </summary>
        /// <param name="id">Unique id.</param>
        /// <param name="description">Description.</param>
        /// <returns>Updated product or null, if wasn't found.</returns>
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
