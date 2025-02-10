
using ShgEcom.Domain.Entites;

namespace ShgEcom.Application.Common.Interfaces.Persistence
{
    public interface IUserRespository
    {
        User? GetUserByEmail(string email);
        void AddUser(User user);
    }
}
