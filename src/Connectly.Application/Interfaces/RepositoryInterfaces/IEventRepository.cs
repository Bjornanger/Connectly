using Connectly.Domain.Entities;

namespace Connectly.Application.Interfaces.RepositoryInterfaces;

public interface IEventRepository : IRepository<Event>
{
    Task<Event> GetById(Guid id);
    Task<List<Event>> GetEventForUserById(Guid id);
    Task<List<Event>> GetEventsOpenForRegistrationAsync();
    Task<List<Event>> GetEventsVisibleToUserAsync();
}