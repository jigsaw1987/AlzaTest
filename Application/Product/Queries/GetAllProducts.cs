using MediatR;

namespace Application.Product.Queries
{
    /// <summary>
    /// Class representing object for get all available products from database.
    /// </summary>
    public sealed class GetAllProducts : IRequest<ICollection<Domain.Entities.Product>>
    {

    }
}
