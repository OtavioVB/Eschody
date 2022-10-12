using Eschody.Domain.Contracts.Infrascructure.Mappings;
using Eschody.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eschody.Infrascructure.Mappings;

public class AssignmentMapping : IBaseMapping<Assignment>
{
    public void CreateMapping(EntityTypeBuilder<Assignment> entity)
    {
        entity.HasKey(p => p.Identifier);

        entity.HasOne(p => p.User).WithMany(p => p.Assignments);
    }
}
