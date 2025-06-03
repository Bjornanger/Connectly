﻿using Connectly.Domain.Entities.Interfaces;
using Connectly.Domain.Enums;

namespace Connectly.Domain.Entities;

public class Event : IEntity<Event>
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool OpenForRegistration { get; set; }

    public bool IsVisibleToUser { get; set; }

    public DateTime EventDate { get; set; }

    public EventType EventType { get; set; }

    public ICollection<UserMeetingRegistrationForm> UserMeetingRegistrationForms { get; set; } = new List<UserMeetingRegistrationForm>();
    public ICollection<EventResource> EventResources { get; set; } = new List<EventResource>();
    public ICollection<Story> Stories { get; set; } = new List<Story>();

    public string? ApplicationUserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }

    public Invitation? Invitation { get; set; }
}