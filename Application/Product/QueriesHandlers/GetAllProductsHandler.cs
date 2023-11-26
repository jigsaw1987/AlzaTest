using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Product.Queries;
using Domain.Interfaces;
using MediatR;

namespace Application.Product.QueriesHandlers
{
    /// <summary>
    /// Handler of getting all products form database.
    /// </summary>
    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, ICollection<Domain.Entities.Product?>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        /// <summary>
        /// Action of handler.
        /// </summary>
        /// <param name="request">Incoming object. <see cref="GetAllProducts"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ICollection<Domain.Entities.Product?>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAll();
        }
    }
}
