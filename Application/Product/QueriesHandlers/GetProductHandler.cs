using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Application.Product.Queries;

namespace Application.Product.QueriesHandlers
{
    public class GetProductHandler : IRequestHandler<GetProduct, Domain.Entities.Product>
    {
        private readonly IProductRepository _repository;

        public GetProductHandler(IProductRepository _productRepository)
        {
            _repository = _productRepository;
        }

        public Task<Domain.Entities.Product> Handle(GetProduct request, CancellationToken cancellationToken)
        {
            return _repository.GetById(request.Id);
        }
    }
}
