using Application.Product.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers.V2
{
    /// <summary>
    /// Controller for products. Version nr. 2
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("2.0")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all products from database with pagination.
        /// </summary>
        /// <returns>List of Product</returns>
        [MapToApiVersion("2.0")]
        [HttpGet]
        [Route("products")]
        public async Task<ICollection<Product>>GetAllProduct(int offset, int limit)
        {
            return await _mediator.Send(new GetAllProductsWithOffset());
        }

    }
}