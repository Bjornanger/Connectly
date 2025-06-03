using System.ComponentModel.DataAnnotations;
using Connectly.Domain.Enums;

namespace Connectly.Application.DTOs;

public class EventDto : ICloneable
{
    public Guid EventId { get; set; }
    [Required(ErrorMessage = "Event name is required")]
    [StringLength(maximumLength: 40)]
    public string EventName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Event description is required")]
    public string EventDescription { get; set; } = string.Empty;
    [Required(ErrorMessage = "Open for registration choice is required")]
    public bool OpenForRegistration { get; set; }
    [Required(ErrorMessage = "Is visible to user choice is required")]
    public bool IsVisibleToUser { get; set; }
    [Required(ErrorMessage = "Event date is required")]
    public DateTime EventDate { get; set; }
    [Required(ErrorMessage = "Event type is required")]
    public EventType EventType { get; set; }

    public string CreatedBy { get; set; } = string.Empty;

    public List<UserMeetingRegistrationFormDto?> UserMeetingRegistrationForms { get; set; } = new List<UserMeetingRegistrationFormDto>();
    public List<ResourceDto>? Resources { get; set; } = new List<ResourceDto>();
    public List<StoryDto?> Stories { get; set; } = new List<StoryDto>();

    public Guid? InvitationId { get; set; }


    /// <returns>A new EventDto object that is a deep copy of this instance.</returns>
    public object Clone()
    {
        var deepCopy = new EventDto()
        {
            EventId = EventId,
            EventName = EventName,
            EventDescription = EventDescription,
            OpenForRegistration = OpenForRegistration,
            IsVisibleToUser = IsVisibleToUser,
            EventDate = EventDate,
            EventType = EventType,
            CreatedBy = CreatedBy,
            UserMeetingRegistrationForms = UserMeetingRegistrationForms,
            Resources = Resources.Select(x => (ResourceDto)x.Clone()).ToList(),
            Stories = Stories,
            InvitationId = InvitationId
        };

        return deepCopy;
    }

    /// <summary>
    /// By default, reference types (like classes) are compared by reference, not by their contents. Even if two Event objects have the same EventId and all other properties, they won't be considered equal unless they are the exact same object in memory.
    /// This override fixes this issue by manually comparing the IDs' of the two event objects.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>If this event ID is equal to argument's event id.</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var otherEvent = (EventDto)obj;
        return EventId == otherEvent.EventId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(EventId);
    }

    /// <returns>List of events with its respective users. Includes events ID, name, date and users. Empty list if argument list is empty or if argument.Event is null.</returns>
    public static List<EventDto> GroupByEvent(List<UserMeetingRegistrationFormDto> users)
    {
        if (!users.Any() || users.Any(x => x.Event is null)) return new List<EventDto>();

        return users
            .GroupBy(x => x.Event)
            .Select(group => new EventDto
            {
                EventId = group.Key.EventId,
                EventName = group.Key.EventName,
                EventDate = group.Key.EventDate,
                UserMeetingRegistrationForms = group.ToList()
            })
            .OrderByDescending(x => x.EventDate)
            .ToList();
    }
}