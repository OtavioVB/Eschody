#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
#pragma warning disable IDE1006 // Estilos de Nomenclatura

using Eschody.Domain.Contracts.Infrascructure.Maps;
using Eschody.Domain.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eschody.Infrascructure.Data;

public class DataContext : IdentityDbContext<IdentityUser>
{
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

#pragma warning restore IDE1006 // Estilos de Nomenclatura
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.