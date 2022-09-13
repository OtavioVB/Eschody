using Eschody.Domain.Contracts.Models.ValueObjects;
using Flunt.Notifications;

namespace Eschody.Domain.Models.ValueObjects.General;

public class Identifier : IIdentifier
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