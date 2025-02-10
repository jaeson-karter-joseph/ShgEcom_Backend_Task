using ErrorOr;
using MediatR;
using ShgEcom.Application.Authentication.Common;

namespace ShgEcom.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
