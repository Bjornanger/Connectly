using Connectly.Application.DTOs;
using Connectly.Application.DTOs.UserDtos;
using Connectly.Domain.Entities;
using FluentResults;

namespace Connectly.Application.Interfaces.ServiceInterfaces;

public interface IUserMeetingRegistrationFormService
{
    Task<Result<IEnumerable<UserMeetingRegistrationFormDto>>> GetAllAsync();
    Task<Result> AddAsync(UserMeetingRegistrationSparseDto? userInput);
   Task<Result> UpdateFormAsync(UserMeetingRegistrationFormDto form, Guid id);
    Task<Result> DeleteFormAsync(Guid id);
    Task<Result<List<UserRegistrationInfoDto>>> GetRegistrationInfoByUserIdAsync(Guid id);

    Task<Result> ConfirmParticipationInEvent(string userId, string eventId);
    Task<Result> SendWelcomeMessageWithAccountConfirmation(UserMeetingRegistrationForm user, string password);
    Task<Result> CreateDefaultAccountAsync(string email, string password);

    Task<Result<string>> CreateWelcomeMessageWithAccountConfirmationLinkAsync(string email, string password,
        Guid eventId);
}