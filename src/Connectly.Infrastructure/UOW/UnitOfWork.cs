using Connectly.Application.Interfaces;
using Connectly.Application.Interfaces.RepositoryInterfaces;
using Connectly.Infrastructure.Data;

namespace Connectly.Infrastructure.UOW;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public IRepositoryFactory _repositoryFactory { get; }
    private readonly Dictionary<Type, object> _repositories;
    
    public UnitOfWork(IRepositoryFactory factory, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _repositoryFactory = factory;
        _repositories = new Dictionary<Type, object>();
    }
    
    public TRepository CreateRepository<TRepository>() where TRepository : class
    {
        if (_repositories.TryGetValue(typeof(TRepository), out var existingRepository))
        {
            return (TRepository)existingRepository;
        }
        var repository = _repositoryFactory.CreateRepository<TRepository>();
        _repositories[typeof(TRepository)] = repository;
        return repository;
    }
    
    public async Task CompleteAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _dbContext.Dispose();
    }
}