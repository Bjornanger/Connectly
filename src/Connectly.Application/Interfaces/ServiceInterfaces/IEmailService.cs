using Microsoft.AspNetCore.Identity.UI.Services;

namespace Connectly.Application.Interfaces.ServiceInterfaces;

public interface IEmailService : IEmailSender
{
    Task Send(string to, string subject, string html);
}