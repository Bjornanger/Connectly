using Connectly.Domain.Enums;

namespace Connectly.Application.DTOs.UserDtos;

public sealed record FileNoDataDto(Guid Id, string Name, FileType Type);