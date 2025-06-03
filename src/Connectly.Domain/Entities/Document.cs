using Connectly.Domain.Entities.Interfaces;
using Connectly.Domain.Enums;

namespace Connectly.Domain.Entities;

public class Document : IEntity<Document>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public FileType Type { get; set; }

    public byte[]? File { get; set; }

    public string FileLocation { get; set; } = string.Empty;

    public Guid ResourceId { get; set; }
    public Resource Resource { get; set; } = null!;

    public string ApplicationUserId { get; set; } = string.Empty;
    public ApplicationUser ApplicationUser { get; set; } = null!;
}