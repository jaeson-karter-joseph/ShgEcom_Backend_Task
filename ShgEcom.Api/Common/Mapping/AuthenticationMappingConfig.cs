using Mapster;
using ShgEcom.Application.Authentication.Common;
using ShgEcom.Contracts.Authentication;


namespace ShgEcom.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>().Map(dest => dest.Token, src => src.Token).Map(dest => dest, src => src.User);
        }
    }
}
