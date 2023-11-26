using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Product.Queries
{
    /// <summary>
    /// Class representing object for get all available products from database.
    /// </summary>
    public class GetAllProducts : IRequest<ICollection<Domain.Entities.Product>>
    {

    }
}
