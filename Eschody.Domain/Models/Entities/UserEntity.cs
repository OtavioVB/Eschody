using Eschody.Domain.Models.ValueObjects;
using Flunt.Notifications;

namespace Eschody.Domain.Models.Entities;

public class UserEntity : Notifiable
{
    public Guid Identifier { get; private set; }
    public Name Name { get; private set; }
    public Nickname Nickname { get; private set; }
    public Email Email { get; private set; }
    public PasswordEncrypted Password { get; private set; }
    public Role Role { get; private set; }
    public DateTime RegisteredOn { get; private set; }

    public UserEntity(Guid identifier, Name name, Nickname nickname, Email email, PasswordEncrypted password, DateTime registeredOn, Role role)
    {
        Identifier = identifier;
        Name = name;
        Nickname = nickname;
        Email = email;
        Password = password;
        RegisteredOn = registeredOn;
        Role = role;

        AppendNotifications(Name, Nickname, Email, Password);
    }
}
