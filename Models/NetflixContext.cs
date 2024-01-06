using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

public class NetflixContext : DbContext
{
    public NetflixContext(DbContextOptions<NetflixContext> options)
        : base(options)
    {
    }

    public DbSet<Account> Account { get; set; } = null!;
    public DbSet<Account> Season { get; set; } = null!;
    public DbSet<Account> Episode { get; set; } = null!;
    public DbSet<Account> WatchableContent { get; set; } = null!;
    public DbSet<Account> ContentType { get; set; } = null!;
    public DbSet<Account> Quality { get; set; } = null!;
    public DbSet<Account> Genre { get; set; } = null!;
    public DbSet<Account> SubtitleSettings { get; set; } = null!;
    public DbSet<Account> SubtitleContent { get; set; } = null!;
}