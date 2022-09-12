#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.

using Eschody.Domain.Models.DTOs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eschody.Infrascructure.Data;

public class DataContext : IdentityDbContext<UserModelIdentity>
{
    public DbSet<UserModelIdentity> Users { get; set; }
    public DbSet<Assignment> Assignments { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        CreateMapForAssignment(builder.Entity<Assignment>());
    }

    private void CreateMapForAssignment(EntityTypeBuilder<Assignment> builder)
    {
        builder.HasKey(p => p.Identifier);
        builder.Property(p => p.Identifier).ValueGeneratedOnAdd();
    }
}

#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.