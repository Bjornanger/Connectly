using Connectly.Application.DTOs;
using Connectly.Application.DTOs.Converters;
using Connectly.Application.Interfaces;
using Connectly.Application.Interfaces.RepositoryInterfaces;
using Connectly.Application.Interfaces.ServiceInterfaces;
using FluentResults;

namespace Connectly.Application.Services;

public class ApplicationUserService : IApplicationUserService
{
    private readonly IUnitOfWork _uow;
    private readonly ISerilogLogger _logger;



    public ApplicationUserService(IUnitOfWork uow, ISerilogLogger logger)
    {
        _uow = uow;
        _logger = logger;
    }


    public async Task<Result<ApplicationUserDto>> GetUserByEmailAsync(string email)
    {

        try
        {
            var userByEmail = await _uow.CreateRepository<IApplicationUserRepository>().GetAllInfoByEmailAsync(email);

            if (userByEmail == null)
            {
                _logger.LogInformation($"No User with Email: {email} found.");
                return Result.Fail($"Användare med email {email} kunde inte hittas.");
            }
            _logger.LogInformation($"User with Email: {email} found.");
            return Result.Ok(userByEmail.ConvertToDto());

        }
        catch (Exception e)
        {
            _logger.LogError("Error", e);
            return Result.Fail(new Error("Ett oväntat fel inträffade").CausedBy(e));
        }


    }
    

}