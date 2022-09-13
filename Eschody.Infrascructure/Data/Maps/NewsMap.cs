using Eschody.Domain.Contracts.Infrascructure.Maps;
using Eschody.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eschody.Infrascructure.Data.Maps;

public class NewsMap : IBaseMap<News>
{
    public void CreateMap(EntityTypeBuilder<News> builder)
    {
        builder.HasKey(p => p.Identifier);
    }
}
