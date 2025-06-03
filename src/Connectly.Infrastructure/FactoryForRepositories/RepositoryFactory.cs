﻿using Connectly.Application.Interfaces.RepositoryInterfaces;
using Connectly.Domain.Entities;
using Connectly.Infrastructure.Data;
using Connectly.Infrastructure.ExternalServices.Excel;
using Connectly.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Connectly.Infrastructure.FactoryForRepositories;

public class RepositoryFactory : IRepositoryFactory
{

    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailSender _emailService;
    private readonly IWorkBook _workBook;
   
    public RepositoryFactory(ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        IEmailSender emailService,
        IWorkBook workBook)
    {
        _workBook = workBook;
        _context = context;
        _userManager = userManager;
        _emailService = emailService;
    }

    public TEntity CreateRepository<TEntity>() where TEntity : class
    {
       
        if (typeof(TEntity)== typeof(IStoryRepository))
        {
            return new StoryRepository(_context) as TEntity;
        }
        if (typeof(TEntity) == typeof(IApplicationUserRepository))
        {
            return new ApplicationUserRepository(_context) as TEntity;
        }
        if (typeof(TEntity) == typeof(IResourceRepository))
        {
            return new ResourceRepository(_context) as TEntity;
        }
        if (typeof(TEntity) == typeof(IEventRepository))
        {
            return new EventRepository(_context) as TEntity;
        }
        if(typeof(TEntity) == typeof(IDocumentRepository))
        {
            return new DocumentRepository(_context) as TEntity;
        }
        if (typeof(TEntity) == typeof(IInvitationRepository))
        {
            return new InvitationRepository(_context) as TEntity;
        }
        if (typeof(TEntity) == typeof(IExcelExportRepository))
        {
            return new ExcelExportRepository(_context, _workBook) as TEntity;
        }
        if (typeof(TEntity) == typeof(IUserMeetingRegistrationFormRepository))
        {
            return new UserMeetingRegistrationFormRepository(_context, _userManager) as TEntity;
        }
        else
        {
            {
                throw new NotSupportedException($"Repository for type: {typeof(TEntity).Name} is not supported.");
            }
        }
    }
}