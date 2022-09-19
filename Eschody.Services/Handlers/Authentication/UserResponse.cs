using Eschody.Domain.Contracts.Services;
using Flunt.Notifications;

namespace Eschody.Services.Handlers.Authentication;

public class UserResponse : Notifiable, IResponse
{
    public int Code { get; private set; }
    public string Message { get; private set; }

    public UserResponse(int statusCode, string message, IReadOnlyCollection<Notification> notifications)
    {
        Code = statusCode;
        Message = message;
        AddNotifications(notifications);
    }
}
