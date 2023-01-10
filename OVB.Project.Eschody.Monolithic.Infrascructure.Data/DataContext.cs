using Microsoft.EntityFrameworkCore;
using OVB.Project.Eschody.Monolithic.Domain.AccountContext.DataTransferObject;
using OVB.Project.Eschody.Monolithic.Domain.AssignmentContext.DataTransferObject;
using OVB.Project.Eschody.Monolithic.Infrascructure.Data.Mapping.Interfaces;

namespace OVB.Project.Eschody.Monolithic.Infrascructure.Data;

public class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; protected set; }
    private readonly IMapping<Account> _accountMapping;

    public DbSet<Assignment> Assignments { get; protected set; }
    private readonly IMapping<Assignment> _assignmentMapping;

    public DataContext(
        IMapping<Account> accountMapping,
        IMapping<Assignment> assignmentMapping,
        DbContextOptions options) 
        : base(options)
    {
        _accountMapping = accountMapping;
        _assignmentMapping = assignmentMapping; 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _accountMapping.CreateMapping(modelBuilder.Entity<Account>());
        _assignmentMapping.CreateMapping(modelBuilder.Entity<Assignment>());
        base.OnModelCreating(modelBuilder);
    }
}
