using Connectly.Domain.Entities;

namespace Connectly.Application.Interfaces.RepositoryInterfaces;

public interface IUserMeetingRegistrationFormRepository : IRepository<UserMeetingRegistrationForm>
{
    Task<List<UserMeetingRegistrationForm>> GetRegistrationInfoByUserIdAsync(Guid id);
    Task<bool> ConfirmParticipationInEvent(string userId, string eventId);
    Task<bool> UserIsAlreadyRegisteredToEvent(UserMeetingRegistrationForm user);
}