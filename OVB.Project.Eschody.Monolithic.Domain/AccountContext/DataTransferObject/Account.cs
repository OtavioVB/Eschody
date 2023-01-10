using OVB.Project.Eschody.Monolithic.Domain.AccountContext.ENUMs;
using OVB.Project.Eschody.Monolithic.Domain.AssignmentContext.DataTransferObject;
using OVB.Project.Eschody.Monolithic.Domain.Base.DataTransferObject;

namespace OVB.Project.Eschody.Monolithic.Domain.AccountContext.DataTransferObject;

public sealed class Account : DataTransferObjectBase
{
    public Account(Guid identifier, string username, string email, string password, TypeAccount typeAccount, DateTime createdOn) : base(identifier, createdOn)
    {
        Username = username;
        Email = email;
        Password = password;
        TypeAccount = typeAccount;
    }

    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public TypeAccount TypeAccount { get; set; }    
    public List<Assignment> Assignments { get; set; } = new List<Assignment>();
}
