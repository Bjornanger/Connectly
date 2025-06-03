using Connectly.Domain.Entities;

namespace Connectly.Application.Interfaces.RepositoryInterfaces;

public interface IInvitationRepository : IRepository<Invitation>
{
    Task<Invitation> GetByIdAsync(Guid id);
    Task<List<Invitation>> GetInvitationsForEventsOpenForRegistrationAsync();
}