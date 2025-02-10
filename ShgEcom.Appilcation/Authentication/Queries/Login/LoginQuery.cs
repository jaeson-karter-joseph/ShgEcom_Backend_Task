using ErrorOr;
using MediatR;
using ShgEcom.Application.Authentication.Common;

namespace ShgEcom.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
