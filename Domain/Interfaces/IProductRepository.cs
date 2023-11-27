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
        /// <summary>
        /// Update product description.
        /// </summary>
        /// <param name="id">Unique id of product.</param>
        /// <param name="description">Description.</param>
        /// <returns>Updated product or null.</returns>
        Task<Product?> UpdateDescription(int id, string description);
    }
}
