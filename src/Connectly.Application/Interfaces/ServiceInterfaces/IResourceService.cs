using Connectly.Application.DTOs;
using FluentResults;

namespace Connectly.Application.Interfaces.ServiceInterfaces;

public interface IResourceService
{
    Task<Result<IEnumerable<ResourceDto>>> GetAllResources();
    Task<Result> AddResourceAsync(ResourceDto resource);
    Task<Result> UpdateResourceAsync(ResourceDto resource, Guid id);
    Task<Result> DeleteResourceAsync(Guid id);
}