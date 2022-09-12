using Eschody.Domain.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Eschody.Infrascructure.Data;

public class UserModelIdentity : IdentityUser
{
    public ICollection<Assignment> Assignments { get; set; }
}

