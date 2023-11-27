using Domain.Interfaces;

namespace Domain.Entities
{
    /// <summary>
    /// Product entity in database.
    /// </summary>
    public class Product : IEntity
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
