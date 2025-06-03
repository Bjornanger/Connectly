namespace Connectly.Application.Interfaces.ServiceInterfaces;

public interface IServiceFactory
{
    TService CreateService<TService>() where TService : class;
}