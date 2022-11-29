using CleanArchitectureDDDTutorial.Domain.Entities;

namespace CleanArchitectureDDDTutorial.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
