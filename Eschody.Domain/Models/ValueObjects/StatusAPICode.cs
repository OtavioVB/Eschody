using Eschody.Domain.Models.ENUMs;

namespace Eschody.Domain.Models.ValueObjects;

public class StatusAPICode
{
    private StatusAPIEnum Value { get; set; }

    public StatusAPICode(StatusAPIEnum value)
    {
        Value = value;
    }

    public int GetStatusCode()
    {
        return (int)Value;
    }

    public StatusAPIEnum GetStatusAPIEnum()
    {
        return Value;
    }
}
