using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetAuthDemo.Data;

public class TDbContext :IdentityDbContext
{
    public TDbContext(DbContextOptions<TDbContext> options) : base(options)
    {
        
    }
}