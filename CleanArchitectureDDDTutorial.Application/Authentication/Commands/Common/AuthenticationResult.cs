using CleanArchitectureDDDTutorial.Domain.Entities;

namespace CleanArchitectureDDDTutorial.Application.Authentication.Commands.Common;

public record AuthenticationResult(
    User User,
    string Token);
