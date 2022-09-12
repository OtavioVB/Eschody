#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.

using Eschody.Domain.Contracts.Infrascructure.Maps;
using Eschody.Domain.Models.DTOs;
using Eschody.Infrascructure.Data.Maps;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eschody.Infrascructure.Data;

public class DataContext : IdentityDbContext<UserModelIdentity>
{
    public override DbSet<UserModelIdentity> Users { get; set; }
    public DbSet<Assignment> Assignments { get; set; }


    // Mapeamentos
    public IBaseMap<Assignment> _assignmentBaseMap { get; private set; }

    public DataContext(DbContextOptions<DataContext> options,[FromServices] IBaseMap<Assignment> assignmentBaseMap)
        : base(options)
    {
        _assignmentBaseMap = assignmentBaseMap;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        _assignmentBaseMap.CreateMap(builder.Entity<Assignment>());
    }
}

#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.