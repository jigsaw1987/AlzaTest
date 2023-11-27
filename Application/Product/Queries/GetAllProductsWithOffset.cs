using MediatR;

namespace Application.Product.Queries
{
    /// <summary>
    /// Class representing object for get all available products from database.
    /// </summary>
    public class GetAllProductsWithOffset : IRequest<ICollection<Domain.Entities.Product>>
    {
        /// <summary>
        /// Offset for items.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Maximum item to get from database.
        /// Default is 10.
        /// </summary>
        public int Limit { get; set; }

    }
}
