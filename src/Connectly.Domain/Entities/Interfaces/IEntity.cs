namespace Connectly.Domain.Entities.Interfaces;

public interface IEntity<T> where T : class
{
    public Guid Id { get; set; }
}