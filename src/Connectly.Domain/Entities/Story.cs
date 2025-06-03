﻿using Connectly.Domain.Entities.Interfaces;

namespace Connectly.Domain.Entities;

public class Story : IEntity<Story>
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string StoryText { get; set; } = string.Empty;

    public string StoryHeading { get; set; } = string.Empty;

    public bool ActiveStory { get; set; }

    public bool PublicStory { get; set; }

    public DateTime StoryCreated { get; set; }

    public Guid ApplicationUser_Id { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public Guid? EventId { get; set; }
    public Event? Event { get; set; }
}