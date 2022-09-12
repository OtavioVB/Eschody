using Eschody.Domain.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eschody.Infrascructure.Data;

public class EschodyApplicationContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Assignment> Assignments { get; set; }

    public EschodyApplicationContext(DbContextOptions<EschodyApplicationContext> options)
        : base(options){ }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        AssignmentModelCreate(builder);
    }

    private void AssignmentModelCreate(ModelBuilder builder)
    {
        builder.Entity<Assignment>().HasKey(p => p.Identifier);
        builder.Entity<Assignment>().Property(p => p.Identifier).ValueGeneratedOnAdd();
    }
}
