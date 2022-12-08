using CleanArchitectureDDDTutorial.Application.Authentication.Commands.Common;
using ErrorOr;
using MediatR;

namespace CleanArchitectureDDDTutorial.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
