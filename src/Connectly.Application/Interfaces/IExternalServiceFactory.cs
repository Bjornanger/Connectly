namespace Connectly.Application.Interfaces;

public interface IExternalServiceFactory
{
    TService CreateExternalService<TService>() where TService : class;
}