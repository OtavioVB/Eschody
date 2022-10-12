using Eschody.Domain.Contracts.Services.Handlers;
using Eschody.Domain.Models.DTOs;
using Flunt.Notifications;

namespace Eschody.Services.Handlers.Authentication.Login;

public class ResponseLoginStudentAccount : Notifiable, IResponse
{
    public Guid Identifier { get; private set; }
    public string StatusCode { get; private set; }
    public string Message { get; private set; }
    public string Localization { get; private set; }

    public string? Token { get; private set; }
    public User? User { get; private set; }

    public ResponseLoginStudentAccount(Guid identifier, string statusCode, string message, string localization, IReadOnlyCollection<Notification> notifications)
    {
        Identifier = identifier;
        StatusCode = statusCode;
        Message = message;
        Localization = localization;
        AddNotifications(notifications);
    }

    public ResponseLoginStudentAccount(Guid identifier, string statusCode, string message, string localization, IReadOnlyCollection<Notification> notifications, string token, User user)
    {
        Identifier = identifier;
        StatusCode = statusCode;
        Message = message;
        Localization = localization;
        Token = token;
        User = user;
        AddNotifications(notifications);
    }
}
