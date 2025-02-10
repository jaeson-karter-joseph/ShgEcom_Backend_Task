using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Domain.Entites;

namespace ShgEcom.Infrastructure.Persistence
{
    public class UserRepository : IUserRespository
    {
        private static readonly List<User> _users = [];
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }
    }
}
