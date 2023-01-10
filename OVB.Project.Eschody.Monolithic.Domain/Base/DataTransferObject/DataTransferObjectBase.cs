namespace OVB.Project.Eschody.Monolithic.Domain.Base.DataTransferObject;

public abstract class DataTransferObjectBase
{
    protected DataTransferObjectBase(Guid identifier, DateTime createdOn)
    {
        Identifier = identifier;
        CreatedOn = createdOn;
    }

    public Guid Identifier { get; set; }
    public DateTime CreatedOn { get; set; }
}
