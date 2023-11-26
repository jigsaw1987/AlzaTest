using Application.Product.Queries;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Product.Command;

namespace Application.Product.CommandHandlers
{
    /// <summary>
    /// Handler for update description.
    /// </summary>
    public class UpdateDescriptionOfProductHandler
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
