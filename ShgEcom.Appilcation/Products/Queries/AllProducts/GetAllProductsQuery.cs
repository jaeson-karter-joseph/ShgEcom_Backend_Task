using ErrorOr;
using MediatR;
using ShgEcom.Application.Products.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShgEcom.Application.Products.Queries.AllProducts
{
    public record GetAllProductsQuery() : IRequest<ErrorOr<List<ProductResult>>>;
}
