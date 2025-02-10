using ErrorOr;
using MediatR;
using ShgEcom.Application.Products.Common;

namespace ShgEcom.Application.Products.Queries.ReadProduct
{
    public record GetProductByIdQuery(Guid ProductId) : IRequest<ErrorOr<ProductResult>>;
}
