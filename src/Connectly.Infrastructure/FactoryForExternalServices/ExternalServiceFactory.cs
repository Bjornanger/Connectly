﻿using Connectly.Application.Interfaces;
using Connectly.Application.Interfaces.ServiceInterfaces;
using Connectly.Infrastructure.ExternalServices;

namespace Connectly.Infrastructure.FactoryForExternalServices;

public class ExternalServiceFactory : IExternalServiceFactory
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISerilogLogger _logger;
    
    public ExternalServiceFactory(IUnitOfWork unitOfWork, ISerilogLogger logger)
    {
        _unitOfWork = unitOfWork;
         _logger = logger;
    }


    public TService CreateExternalService<TService>() where TService : class
    {
        _logger.LogInformation($"Creating service for type: {typeof(TService).Name}");
        if (typeof(TService) == typeof(IExcelExportService))
        {
            return new ExcelExportService(_unitOfWork, _logger) as TService;
        }

        else
        {
            {
                throw new NotSupportedException($"Service for type: {typeof(TService).Name} is not supported.");
            }
        }
    }
}
