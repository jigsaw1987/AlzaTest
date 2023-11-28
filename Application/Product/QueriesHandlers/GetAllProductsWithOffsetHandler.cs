using Application.Product.Queries;
using Domain.Interfaces;
using MediatR;

namespace Application.Product.QueriesHandlers
{
    /// <summary>
    /// Handler of getting product with offset. Specially for pagination.
    /// </summary>
    public sealed class GetAllProductsWithOffsetHandler : IRequestHandler<GetAllProductsWithOffset, ICollection<Domain.Entities.Product?>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productRepository"></param>
        public GetAllProductsWithOffsetHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Action of handler.
        /// </summary>
        /// <param name="request">Incoming object. <see cref="GetAllProductsWithOffset"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Collection of <see cref="Product"/></returns>
        public async Task<ICollection<Domain.Entities.Product?>> Handle(GetAllProductsWithOffset request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAll(request.Offset, request.Limit);
        }
    }
}
