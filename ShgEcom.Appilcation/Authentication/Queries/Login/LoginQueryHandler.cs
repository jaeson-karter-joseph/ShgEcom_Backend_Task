using ErrorOr;
using MediatR;
using ShgEcom.Application.Authentication.Common;
using ShgEcom.Application.Common.Interfaces.Authentication;
using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Domain.Entites;

namespace ShgEcom.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler(IUserRespository _userRespository, IJwtTokenGenerator _jwtTokenGenerator) : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (_userRespository.GetUserByEmail(query.Email) is not User user)
            {
                return Domain.Errors.Errors.Authentication.InvalidEmail;
            }

            //Validate Password
            if (user.Password != query.Password)
            {
                return new[] { Domain.Errors.Errors.Authentication.InvalidPassword, Domain.Errors.Errors.Authentication.InvalidEmail };
            }

            var token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(user, token);
        }
    }
}
