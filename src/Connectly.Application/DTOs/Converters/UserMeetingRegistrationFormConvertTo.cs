using Connectly.Application.DTOs.UserDtos;
using Connectly.Domain.Entities;

namespace Connectly.Application.DTOs.Converters;

public static class UserMeetingRegistrationFormConvertTo
{
   
    public static UserMeetingRegistrationFormDto ConvertToDto(this UserMeetingRegistrationForm m)
    {
        var d = new UserMeetingRegistrationFormDto()
        {
            Id = m.Id,
            Accommodation = m.Accommodation,
            UserInformation = m.UserInformation,
            PhoneNumber = m.PhoneNumber,
            AccommodationWith = m.AccommodationWith,
            AgreeToSavePersonalData = m.AgreeToSavePersonalData,
            Allergies = m.Allergies,
            Company = m.Company,
            Confirmed = m.Confirmed,
            Email = m.Email,
            FamilyName = m.LastName,
            FirstName = m.FirstName,
            InvoiceReference = m.InvoiceReference,
            Event = new EventDto() { EventId = m.EventId, EventName = m.Event.Name, EventDate = m.Event.EventDate }
        };

        return d;
    }

    public static UserMeetingRegistrationForm ConvertToModel(this UserMeetingRegistrationFormDto d)
    {
        return new UserMeetingRegistrationForm()
        {
            Id = d.Id,
            Event = new Event() { Id = d.Event.EventId },
            FirstName = d.FirstName,
            LastName = d.FamilyName,
            Email = d.Email,
            PhoneNumber = d.PhoneNumber,
            Company = d.Company,
            Accommodation = d.Accommodation,
            AccommodationWith = d.AccommodationWith,
            AgreeToSavePersonalData = d.AgreeToSavePersonalData,
            Allergies = d.Allergies,
            InvoiceReference = d.InvoiceReference,
            UserInformation = d.UserInformation,
            Confirmed = d.Confirmed,
        };
    }

    public static UserMeetingRegistrationFormDto ConvertToDto(this UserMeetingRegistrationSparseDto s)
    {
        return new UserMeetingRegistrationFormDto()
        {
            Event = new EventDto() { EventId = s.Event.EventId },
            FirstName = s.FirstName,
            FamilyName = s.FamilyName,
            Email = s.Email,
            PhoneNumber = s.PhoneNumber,
            Company = s.Company,
            Accommodation = s.Accommodation,
            AccommodationWith = s.AccommodationWith,
            AgreeToSavePersonalData = s.AgreeToSavePersonalData,
            Allergies = s.Allergies,
            InvoiceReference = s.InvoiceReference,
            UserInformation = s.UserInformation
        };
    }
}