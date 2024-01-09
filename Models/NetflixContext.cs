using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

public class NetflixContext : DbContext
{
    public NetflixContext(DbContextOptions<NetflixContext> options)
        : base(options)
    {
    }

    public DbSet<Account> Account { get; set; } = null!;
}