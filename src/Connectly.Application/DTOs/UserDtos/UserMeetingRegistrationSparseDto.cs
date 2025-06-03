using System.ComponentModel.DataAnnotations;
using Connectly.Domain.Attribute;
using Connectly.Domain.Enums;

namespace Connectly.Application.DTOs.UserDtos;

public sealed class UserMeetingRegistrationSparseDto()
{
    public EventInvitationInfoForRegistrationDto Event { get; set; }

    [Required(ErrorMessage = "Förnamn saknas.")]
    [TableColumn(columnHeading: "First Name", columnId: 1)]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Efternamn saknas.")]
    [TableColumn(columnHeading: "Family Name", columnId: 2)]
    public string FamilyName { get; set; } = null!;

    [Required(ErrorMessage = "Epost saknas.")]
    [EmailAddress(ErrorMessage = "Epostadressen är inte korrekt.")]
    [TableColumn(columnHeading: "Email", columnId: 4)]
    public string Email { get; set; } = null!;

    [TableColumn(columnHeading: "Phone Number", columnId: 5)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Företag saknas.")]
    [TableColumn(columnHeading: "Company", columnId: 3)]
    public string Company { get; set; } = null!;

    [TableColumn(columnHeading: "Invoice Reference", columnId: 13)]
    public string InvoiceReference { get; set; } = string.Empty;

    [TableColumn(columnHeading: "Accomodation", columnId: 6)]
    public Accommodation Accommodation { get; set; }

    [TableColumn(columnHeading: "AccomodationWith", columnId: 7)]
    public string AccommodationWith { get; set; } = string.Empty;

    [TableColumn(columnHeading: "Allergies", columnId: 8)]
    public string Allergies { get; set; } = string.Empty;

    [TableColumn(columnHeading: "UserInformation", columnId: 9)]
    public string UserInformation { get; set; } = string.Empty;

    [Required]
    [Range(typeof(bool), "true", "true", ErrorMessage = "För att kunna delta i evenemanget behöver medgivande till sparande av personuppgifter medges.")]
    [TableColumn(columnHeading: "AgreeToSavePersonalData", columnId: 10)]
    public bool AgreeToSavePersonalData { get; set; }
}