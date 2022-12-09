using CleanArchitectureDDDTutorial.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CleanArchitectureDDDTutorial.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
