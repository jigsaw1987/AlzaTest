﻿using Application.Product.Queries;
using Domain.Interfaces;
using MediatR;

namespace Application.Product.QueriesHandlers
{
    /// <summary>
    /// Handler of getting all products form database.
    /// </summary>
    public sealed class GetAllProductsHandler : IRequestHandler<GetAllProducts, ICollection<Domain.Entities.Product?>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productRepository"></param>
        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Action of handler.
        /// </summary>
        /// <param name="request">Incoming object. <see cref="GetAllProducts"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Collection of <see cref="Product"/></returns>
        public async Task<ICollection<Domain.Entities.Product?>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAll();
        }
    }
}
