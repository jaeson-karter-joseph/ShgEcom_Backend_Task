using ErrorOr;
using MediatR;
using ShgEcom.Application.Products.Common;

namespace ShgEcom.Application.Products.Commands.Update
{
    public record UpdateProductCommand(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        int StockQuantity,
        List<string> Tags
    ) : IRequest<ErrorOr<ProductResult>>;
}
