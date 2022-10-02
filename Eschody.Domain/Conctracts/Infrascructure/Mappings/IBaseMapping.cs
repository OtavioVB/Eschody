using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eschody.Domain.Conctracts.Infrascructure.Mappings;

public interface IBaseMapping<T> where T : class
{
    public void CreateMapping(EntityTypeBuilder<T> builder);
}