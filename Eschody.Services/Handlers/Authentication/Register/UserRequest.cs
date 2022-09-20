using Eschody.Domain.Contracts.Services;
using Eschody.Domain.Models.ValueObjects.UserObject;
using Flunt.Notifications;

namespace Eschody.Services.Handlers.Authentication.Register;

public class UserRequest : Notifiable, IRequest
{
    public Guid RequestIdentifier { get; private set; }
    public DateTime Moment { get; private set; }
    public Email Email { get; private set; }
    public Username Username { get; private set; }
    public PasswordNotEncrypted PasswordNotEncrypted { get; private set; }
    public PasswordNotEncrypted PasswordNotEncryptedConfirm { get; private set; }

    public UserRequest(Guid requestIdentifier, DateTime moment, Email email, Username username, PasswordNotEncrypted passwordNotEncrypted, PasswordNotEncrypted passwordNotEncryptedConfirm)
    {
        RequestIdentifier = requestIdentifier;
        Moment = moment;
        Email = email;
        Username = username;
        PasswordNotEncrypted = passwordNotEncrypted;
        PasswordNotEncryptedConfirm = passwordNotEncryptedConfirm;

        AppendNotifications(Username, PasswordNotEncrypted, PasswordNotEncryptedConfirm, Email);
    }
}
