using Connectly.Domain.Entities;

namespace Connectly.Application.Interfaces.RepositoryInterfaces;

public interface IApplicationUserRepository
{
    Task<ApplicationUser> GetAllInfoByEmailAsync(string email);
}