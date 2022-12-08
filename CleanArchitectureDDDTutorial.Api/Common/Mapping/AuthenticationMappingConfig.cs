using CleanArchitectureDDDTutorial.Application.Authentication.Commands.Common;
using CleanArchitectureDDDTutorial.Application.Authentication.Commands.Register;
using CleanArchitectureDDDTutorial.Application.Authentication.Queries.Login;
using CleanArchitectureDDDTutorial.Contracts.Authentication;
using Mapster;

namespace CleanArchitectureDDDTutorial.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}
