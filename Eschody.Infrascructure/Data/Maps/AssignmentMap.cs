using Eschody.Domain.Contracts.Infrascructure.Maps;
using Eschody.Domain.Models.DTOs;

namespace Eschody.Infrascructure.Data.Maps;

public class AssignmentMap : IBaseMap<Assignment> 
{
    public void CreateMap(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Assignment> builder)
    {
        builder.HasKey(p => p.Identifier);
        builder.Property(p => p.Identifier).ValueGeneratedOnAdd();
    }
}
