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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Description = "Test description 1",
                ImgUri = @"D:\images\test",
                Name = "Test product 1",
                Price = 1000
            },
            new Product
            {
                Id = 2,
                Description = "Test description 2",
                ImgUri = @"D:\images\test",
                Name = "Test product 2",
                Price = 3
            },
            new Product
            {
                Id = 3,
                Description = "Test description 3",
                ImgUri = @"D:\images\test",
                Name = "Test product 3",
                Price = 59870
            },
            new Product
            {
                Id = 4,
                Description = "Test description 4",
                ImgUri = @"D:\images\test",
                Name = "Test product 4",
                Price = 548
            },
            new Product
            {
                Id = 5,
                Description = "Test description 5",
                ImgUri = @"D:\images\test",
                Name = "Test product 5",
                Price = 213
            }, 
            new Product
            {
                Id = 6,
                Description = "Test description 6",
                ImgUri = @"D:\images\test",
                Name = "Test product 6",
                Price = 6000
            },
            new Product
            {
                Id = 7,
                Description = "Test description 7",
                ImgUri = @"D:\images\test",
                Name = "Test product 7",
                Price = 1123
            }
        );
    }
}