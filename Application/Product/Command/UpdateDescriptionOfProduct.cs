using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Product.Command
{
    /// <summary>
    /// Class representing object of description update command.
    /// <see cref="Application.Product.CommandHandlers.UpdateDescriptionOfProductHandler"/>
    /// </summary>
    public sealed class UpdateDescriptionOfProduct : IRequest<Domain.Entities.Product>
    {
        /// <summary>
        /// Unique id of product.
        /// </summary>
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Description of product.
        /// </summary>
        public string? Description { get; set; }
    }
}
