#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.

using Eschody.Domain.Conctracts.Infrascructure.Mappings;
using Eschody.Domain.Models.DTOs;
using Eschody.Infrascructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Eschody.Infrascructure.Data;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        IBaseMapping<User> userMapping = new UserMapping();
        userMapping.CreateMapping(modelBuilder.Entity<User>());

        base.OnModelCreating(modelBuilder);
    }
}

#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.