using Connectly.Application.DTOs;
using Connectly.Application.DTOs.UserDtos;
using FluentResults;

namespace Connectly.Application.Interfaces.ServiceInterfaces;

public interface IStoryService
{
    Task<Result> CreateStory(StoryDto story);
    Task<Result<List<StoryDto>>> GetAllStories();
    Task<Result<StoryDto>> GetStoryById(Guid id);
    Task<Result<List<StorySparseDto>>> GetActiveStories();
    Task<Result<List<StorySparseDto>>> GetPublicStories();
    Task<Result> UpdateStory(StoryDto story, Guid id);
    Task<Result> DeleteStory(Guid id);
}