using DotNetAuthDemo.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetAuthDemo.Data;

public class TDbContext :IdentityDbContext<Person>
{
    public TDbContext(DbContextOptions<TDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Person>().Property(p => p.Initials).HasMaxLength(5);

        builder.HasDefaultSchema("identity");
    }
}