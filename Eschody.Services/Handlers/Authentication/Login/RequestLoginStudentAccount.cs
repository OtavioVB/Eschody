using Eschody.Domain.Contracts.Services.Handlers;
using Eschody.Domain.Models.ValueObjects;
using Flunt.Notifications;

namespace Eschody.Services.Handlers.Authentication.Login;

public class RequestLoginStudentAccount : Notifiable, IRequest
{
    public Guid Identifier { get; private set; }
    public DateTime RequestTime { get; private set; }
    public Nickname Nickname { get; private set; }
    public PasswordNotEncrypted PasswordNotEncrypted { get; private set; }

    public RequestLoginStudentAccount(Guid identifier, DateTime dateTime, Nickname nickname, PasswordNotEncrypted passwordNotEncrypted)
    {
        Identifier = identifier;
        RequestTime = dateTime;
        Nickname = nickname;
        PasswordNotEncrypted = passwordNotEncrypted;

        AppendNotifications(Nickname, PasswordNotEncrypted);
    }
}
