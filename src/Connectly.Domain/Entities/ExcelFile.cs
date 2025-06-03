using Connectly.Domain.Entities.Interfaces;

namespace Connectly.Domain.Entities;

public class ExcelFile : IEntity<ExcelFile>
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Path { get; set; } = string.Empty;

    public string ApplicationUserId { get; set; } = string.Empty;

    public ApplicationUser ApplicationUser { get; set; } = null!;
}