using ErrorOr;
using MediatR;

namespace ShgEcom.Application.Products.Commands.Delete
{
    public record DeleteProductCommand(Guid Id) : IRequest<ErrorOr<bool>>;
}
