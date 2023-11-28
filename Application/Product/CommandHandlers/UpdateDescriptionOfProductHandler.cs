using Domain.Interfaces;
using Application.Product.Command;
using MediatR;

namespace Application.Product.CommandHandlers
{
    /// <summary>
    /// Handler for update description.
    /// </summary>
    public sealed class UpdateDescriptionOfProductHandler : IRequestHandler<UpdateDescriptionOfProduct, Domain.Entities.Product?>
    {
        private readonly IProductRepository _repository;

        public UpdateDescriptionOfProductHandler(IProductRepository _productRepository)
        {
            _repository = _productRepository;
        }

        /// <summary>
        /// Action for handler.
        /// </summary>
        /// <param name="request">Incoming object. <see cref="UpdateDescriptionOfProduct"/></param>
        /// <param name="cancellationToken">Token for cancel async thread.</param>
        /// <returns><see cref="Product"/></returns>
        public Task<Domain.Entities.Product?> Handle(UpdateDescriptionOfProduct request, CancellationToken cancellationToken)
        {
            return _repository.UpdateDescription(request.Id, request.Description);
        }
    }
}
