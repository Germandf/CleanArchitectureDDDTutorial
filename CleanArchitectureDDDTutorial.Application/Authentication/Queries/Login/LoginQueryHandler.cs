using CleanArchitectureDDDTutorial.Application.Authentication.Common;
using CleanArchitectureDDDTutorial.Application.Common.Interfaces.Authentication;
using CleanArchitectureDDDTutorial.Application.Common.Interfaces.Persistence;
using CleanArchitectureDDDTutorial.Domain.Common.Errors;
using CleanArchitectureDDDTutorial.Domain.Entities;
using ErrorOr;
using MediatR;

namespace CleanArchitectureDDDTutorial.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRepository.GetUserByEmail(query.Email) is not User user)
            return Errors.Authentication.InvalidCredentials;

        if (user.Password != query.Password)
            return Errors.Authentication.InvalidCredentials;

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
