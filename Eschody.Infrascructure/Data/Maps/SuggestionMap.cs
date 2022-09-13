using Eschody.Domain.Contracts.Infrascructure.Maps;
using Eschody.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eschody.Infrascructure.Data.Maps;

public class SuggestionMap : IBaseMap<Suggestion>
{
    public void CreateMap(EntityTypeBuilder<Suggestion> builder)
    {
        builder.HasKey(p => p.Identifier);
        builder.Property(p => p.Identifier).ValueGeneratedOnAdd();
    }
}
