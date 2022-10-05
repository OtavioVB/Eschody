using Eschody.Domain.Models.ENUMs;

namespace Eschody.Domain.Models.ValueObjects;

public class Role
{
    private RolesEnum Value { get; set; }
    private string RoleName { get; set; }

    public Role(RolesEnum value)
    {
        Value = value;
        RoleName = value.ToString();
    }

    public RolesEnum GetRolesEnum()
    {
        return Value;
    }

    public override string ToString()
    {
        return RoleName;
    }
}
