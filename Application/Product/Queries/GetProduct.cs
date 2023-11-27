using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Product.Queries
{
    /// <summary>
    /// Class representing object of input for query GetProduct.
    /// <see cref="Application.Product.QueriesHandlers.GetProductHandler"/>
    /// </summary>
    public sealed class GetProduct : IRequest<Domain.Entities.Product>
    {
        /// <summary>
        /// Unique Id of product in database.
        /// </summary>
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
    }
}
