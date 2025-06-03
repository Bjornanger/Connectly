using Connectly.Domain.Enums;

namespace Connectly.Application.DTOs.UserDtos;

public sealed record FileDataDto(string Name, byte[] Data, FileType Type);