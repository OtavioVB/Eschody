using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eschody.Domain.Contracts.Infrascructure.Maps;

public interface IBaseMap<T> where T : class
{
    public void CreateMap(EntityTypeBuilder<T> builder);
}
