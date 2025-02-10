using ErrorOr;
using MediatR;
using ShgEcom.Application.Products.Common;

namespace ShgEcom.Application.Products.Queries.ReadProductByTag
{
    public record GetProductsByTagQuery(string Tag) : IRequest<ErrorOr<List<ProductResult>>>;
}
