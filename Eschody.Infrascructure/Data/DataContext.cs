#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
#pragma warning disable IDE1006 // Estilos de Nomenclatura

using Eschody.Domain.Contracts.Infrascructure.Maps;
using Eschody.Domain.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eschody.Infrascructure.Data;

public class DataContext : DbContext
{
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Suggestion> Suggestions { get; set; }
    public DbSet<News> News { get; set; }

    // Mapeamentos
    public IBaseMap<Assignment> _assignmentBaseMap { get; private set; }
    public IBaseMap<Suggestion> _suggestionBaseMap { get; private set; }
    public IBaseMap<News> _newsBaseMap { get; private set; }

    public DataContext(DbContextOptions<DataContext> options, 
        [FromServices] IBaseMap<Assignment> assignmentBaseMap, [FromServices] IBaseMap<Suggestion> suggestionBaseMap, [FromServices] IBaseMap<News> newsBaseMap)
        : base(options)
    {
        _newsBaseMap = newsBaseMap;
        _assignmentBaseMap = assignmentBaseMap;
        _suggestionBaseMap = suggestionBaseMap;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        _newsBaseMap.CreateMap(builder.Entity<News>());
        _suggestionBaseMap.CreateMap(builder.Entity<Suggestion>());
        _assignmentBaseMap.CreateMap(builder.Entity<Assignment>());
    }
}

#pragma warning restore IDE1006 // Estilos de Nomenclatura
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.