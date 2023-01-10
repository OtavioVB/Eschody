using OVB.Project.Eschody.Monolithic.Domain.AccountContext.DataTransferObject;
using OVB.Project.Eschody.Monolithic.Domain.AssignmentContext.ENUMs;
using OVB.Project.Eschody.Monolithic.Domain.Base.DataTransferObject;

namespace OVB.Project.Eschody.Monolithic.Domain.AssignmentContext.DataTransferObject;

public sealed class Assignment : DataTransferObjectBase
{
    public Assignment(Guid identifier, DateTime createdOn, string description, TypeStatusAssignment typeStatusAssignment, DateTime deadline) : base(identifier, createdOn)
    {
        Description = description;
        TypeStatusAssignment = typeStatusAssignment;
        Deadline = deadline;
    }

    public string Description { get; set; }
    public TypeStatusAssignment TypeStatusAssignment { get; set; }
    public DateTime Deadline { get; set; }
    public Account? CreatedBy { get; set; }
}
