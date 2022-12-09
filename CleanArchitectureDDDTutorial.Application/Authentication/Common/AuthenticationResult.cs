using CleanArchitectureDDDTutorial.Domain.Entities;

namespace CleanArchitectureDDDTutorial.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);
