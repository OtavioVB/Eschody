using Eschody.Domain.Conctracts.Infrascructure.Mappings;
using Eschody.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eschody.Infrascructure.Mappings;

public class UserMapping : IBaseMapping<User>
{
    public void CreateMapping(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(p => p.Identifier);
    }
}
