using Eschody.Domain.Contracts.Models.ValueObjects;
using Flunt.Notifications;

namespace Eschody.Domain.Models.ValueObjects;

public class Identifier : Notifiable<Notification>, IIdentifier
{
    public int Value { get; private set; }

    public Identifier(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}