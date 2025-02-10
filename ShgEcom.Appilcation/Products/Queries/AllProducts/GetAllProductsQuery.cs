using ErrorOr;
using MediatR;
using ShgEcom.Application.Products.Common;

namespace ShgEcom.Application.Products.Queries.AllProducts
{
    public record GetAllProductsQuery() : IRequest<ErrorOr<List<ProductResult>>>;
}
