using Eschody.Domain.Contracts.Infrascructure.Maps;
using Eschody.Domain.Models.DTOs;

namespace Eschody.Infrascructure.Data.Maps;

public class UserMap : IBaseMap<User>
{
    public void CreateMap(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        builder.HasKey(p => p.Identifier);
    }
}
