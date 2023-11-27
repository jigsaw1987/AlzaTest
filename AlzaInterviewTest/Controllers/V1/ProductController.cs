using Application.Product.Command;
using Application.Product.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers.V1
{
    /// <summary>
    /// Controller for products. Version nr. 1.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
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
        /// Get specified product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product</returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        [Route("product")]
        public async Task<Product> GetProduct(int id)
        {
            return await _mediator.Send(new GetProduct() { Id = id });
        }

        /// <summary>
        /// Get all products from database.
        /// </summary>
        /// <returns>List of Product.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        [Route("products")]
        public async Task<ICollection<Product>> GetAllProduct()
        {
            return await _mediator.Send(new GetAllProducts());
        }

        /// <summary>
        /// Update description of product by id.
        /// </summary>
        /// <param name="id">Unique id of product.</param>
        /// <param name="description">Description.</param>
        /// <returns>Updated product.</returns>
        [MapToApiVersion("1.0")]
        [HttpPut]
        [Route("update-description")]
        public async Task<Product> UpdateDescription(int id, string description)
        {
            return await _mediator.Send(new UpdateDescriptionOfProduct() { Id = id, Description = description });
        }
    }
}