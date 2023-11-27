using MediatR;
using Domain.Interfaces;
using Application.Product.Queries;

namespace Application.Product.QueriesHandlers
{
    /// <summary>
    /// Handler of getting one product from database depends on id.
    /// </summary>
    public sealed class GetProductHandler : IRequestHandler<GetProduct, Domain.Entities.Product>
    {
        private readonly IProductRepository _repository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="_productRepository"></param>
        public GetProductHandler(IProductRepository _productRepository)
        {
            _repository = _productRepository;
        }

        /// <summary>
        /// Action of handler.
        /// </summary>
        /// <param name="request">Incoming object. <see cref="GetProduct"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Product"/></returns>
        public Task<Domain.Entities.Product> Handle(GetProduct request, CancellationToken cancellationToken)
        {
            return _repository.GetById(request.Id);
        }
    }
}
