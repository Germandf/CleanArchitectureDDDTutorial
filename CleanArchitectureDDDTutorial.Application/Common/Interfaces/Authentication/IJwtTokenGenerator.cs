using CleanArchitectureDDDTutorial.Domain.Entities;

namespace CleanArchitectureDDDTutorial.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
