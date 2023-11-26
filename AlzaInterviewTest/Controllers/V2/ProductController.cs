using System.ComponentModel.DataAnnotations;
using Application.Product.Command;
using Application.Product.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers.V2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all products from database.
        /// </summary>
        /// <returns>List of Product</returns>
        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<ICollection<Product>> GetAllProduct()
        {
            return await _mediator.Send(new GetAllProducts());
        }

    }
}