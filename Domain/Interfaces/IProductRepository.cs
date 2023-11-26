using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    /// <summary>
    /// Specific interface for Product.
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> UpdateDescription(int id, string description);
    }
}
