using Connectly.Domain.Entities;

namespace Connectly.Application.Interfaces.RepositoryInterfaces;

public interface IResourceRepository : IRepository<Resource>
{
    Task<Resource> GetByIdAsync(Guid id);
}