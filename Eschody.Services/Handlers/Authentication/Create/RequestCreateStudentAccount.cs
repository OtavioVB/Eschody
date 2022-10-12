using Eschody.Domain.Contracts.Services.Handlers;
using Eschody.Domain.Models.ValueObjects;
using Flunt.Notifications;

namespace Eschody.Services.Handlers.Authentication.Create;

public class RequestCreateStudentAccount : Notifiable, IRequest
{
    public Guid Identifier { get; private set; }
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Nickname Nickname { get; private set; }
    public PasswordNotEncrypted PasswordNotEncrypted { get; private set; }
    public Role Role { get; private set; }
    public DateTime RequestTime { get; private set; }

    public RequestCreateStudentAccount(Name name, Email email, Nickname nickname, PasswordNotEncrypted passwordNotEncrypted, Role role)
    {
        Identifier = Guid.NewGuid();
        Name = name;
        Email = email;
        Nickname = nickname;
        PasswordNotEncrypted = passwordNotEncrypted;
        Role = role;
        RequestTime = DateTime.Now;

        AppendNotifications(Name, Email, Nickname, PasswordNotEncrypted);
    }
}
