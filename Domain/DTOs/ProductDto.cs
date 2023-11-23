using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public sealed class ProductDto
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of product.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Path to image of product.
        /// </summary>
        public string ImgUri { get; set; } = string.Empty;

        /// <summary>
        /// Price of product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Description of product.
        /// </summary>
        public string? Description { get; set; }
    }
}
