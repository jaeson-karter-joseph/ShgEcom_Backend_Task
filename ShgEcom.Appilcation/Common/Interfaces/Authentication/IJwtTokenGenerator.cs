using ShgEcom.Domain.Entites;

namespace ShgEcom.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
