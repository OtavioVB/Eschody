using Eschody.Domain.Conctracts.Infrascructure.Mappings;
using Eschody.Domain.Models.DTOs;
using Eschody.Infrascructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eschody.Infrascructure.Data;

public class DataContext : DbContext
{
    public DbSet<User>? Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        IBaseMapping<User> userMapping = new UserMapping();
        userMapping.CreateMapping(modelBuilder.Entity<User>());

        base.OnModelCreating(modelBuilder);
    }
}
