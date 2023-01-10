using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OVB.Project.Eschody.Monolithic.Infrascructure.Data.Mapping.Interfaces;

public interface IMapping<TDataTransferObject>
    where TDataTransferObject : class
{
    public void CreateMapping(EntityTypeBuilder<TDataTransferObject> entity);
}
