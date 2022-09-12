using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eschody.Infrascructure.Data;

public class EschodyApplicationContext : IdentityDbContext<IdentityUser>
{
    public EschodyApplicationContext(DbContextOptions<EschodyApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
