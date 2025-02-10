using Mapster;
using ShgEcom.Application.Authentication.Commands.Register;
using ShgEcom.Application.Authentication.Common;
using ShgEcom.Application.Authentication.Queries.Login;
using ShgEcom.Contracts.Authentication;


namespace ShgEcom.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>().Map(dest => dest.Token, src => src.Token).Map(dest => dest, src => src.User);
        }
    }
}
