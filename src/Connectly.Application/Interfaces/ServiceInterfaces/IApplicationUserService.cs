using Connectly.Application.DTOs;
using FluentResults;

namespace Connectly.Application.Interfaces.ServiceInterfaces;

public interface IApplicationUserService
{
   Task<Result<ApplicationUserDto>> GetUserByEmailAsync(string email);
   
}