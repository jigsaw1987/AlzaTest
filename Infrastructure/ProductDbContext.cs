using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

/// <summary>
/// Database context.
/// </summary>
public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Product?> Products { get; set; }
}