using ShgEcom.Domain.Entites;

namespace ShgEcom.Application.Authentication.Common
{
    public record AuthenticationResult(User User, string Token);
}
