using Connectly.Application.Interfaces;
using Connectly.Application.Interfaces.ServiceInterfaces;
using Connectly.Application.Services;
using Connectly.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Connectly.Application.FactoryForServices;

public class ServiceFactory : IServiceFactory
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISerilogLogger _logger;
    private readonly IPasswordGeneratorService _passwordService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailService _emailService;

    public ServiceFactory(
        IUnitOfWork unitOfWork,
        ISerilogLogger logger,
        IPasswordGeneratorService passwordService,
        UserManager<ApplicationUser> userManager,
        IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _passwordService = passwordService;
        _userManager = userManager;
        _emailService = emailService;

    }

    public TService CreateService<TService>() where TService : class
    {
        _logger.LogInformation($"Creating service for type: {typeof(TService).Name}");

        if (typeof(TService) == typeof(IStoryService))
        {
            return new StoryService(_unitOfWork, _logger) as TService;
        }
        if (typeof(TService) == typeof(IResourceService))
        {
            return new ResourceService(_unitOfWork, _logger) as TService;
        }
        if (typeof(TService) == typeof(IInvitationService))
        {
            return new InvitationService(_unitOfWork, _logger) as TService;
        }
        if (typeof(TService) == typeof(IEventService))
        {
            return new EventService(_unitOfWork, _logger) as TService;
        }
        if (typeof(TService) == typeof(IDocumentService))
        {
            return new DocumentService(_unitOfWork, _logger) as TService;
        }
        if (typeof(TService) == typeof(IApplicationUserService))
        {
            return new ApplicationUserService(_unitOfWork, _logger) as TService;
        }
        if (typeof(TService) == typeof(IUserMeetingRegistrationFormService))
        {
            return new UserMeetingRegistrationFormService(_unitOfWork, _passwordService, _userManager, _logger, _emailService) as TService;
        }
        else
        {
            {
                throw new NotSupportedException($"Service for type: {typeof(TService).Name} is not supported.");
            }
        }
    }
}