using CleanArchitectureDDDTutorial.Domain.Entities;

namespace CleanArchitectureDDDTutorial.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);
