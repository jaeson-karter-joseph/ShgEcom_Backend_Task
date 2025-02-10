using ErrorOr;
using MediatR;
using ShgEcom.Application.Authentication.Common;
using ShgEcom.Application.Common.Interfaces.Authentication;
using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Domain.Entites;

namespace ShgEcom.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler(IUserRespository _userRespository, IJwtTokenGenerator _jwtTokenGenerator) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (_userRespository.GetUserByEmail(command.Email) is not null)
            {
                return Domain.Errors.Errors.User.DuplicateEmail;
            }

            //Create User (Generate unique ID)
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            _userRespository.AddUser(user);

            //Generate JWT
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
