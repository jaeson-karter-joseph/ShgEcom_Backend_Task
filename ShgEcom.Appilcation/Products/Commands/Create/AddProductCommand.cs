using ErrorOr;
using MediatR;
using ShgEcom.Application.Products.Common;

namespace ShgEcom.Application.Products.Commands.Create
{
    public record AddProductCommand(string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    int ProductStatus,
    List<string> Tags) : IRequest<ErrorOr<ProductResult>>;
}
