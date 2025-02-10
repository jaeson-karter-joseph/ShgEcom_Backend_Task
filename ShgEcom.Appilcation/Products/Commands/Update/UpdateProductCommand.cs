using ErrorOr;
using MediatR;
using ShgEcom.Application.Products.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
