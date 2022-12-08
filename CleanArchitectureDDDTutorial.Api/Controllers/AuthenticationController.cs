using CleanArchitectureDDDTutorial.Application.Authentication.Commands.Common;
using CleanArchitectureDDDTutorial.Application.Authentication.Commands.Register;
using CleanArchitectureDDDTutorial.Application.Authentication.Queries.Login;
using CleanArchitectureDDDTutorial.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureDDDTutorial.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        var authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await _mediator.Send(query);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                        authResult.User.Id,
                        authResult.User.FirstName,
                        authResult.User.LastName,
                        authResult.User.Email,
                        authResult.Token);
    }
}
