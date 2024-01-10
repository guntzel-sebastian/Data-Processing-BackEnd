using Microsoft.EntityFrameworkCore;
using NetflixAPI.Models;

namespace NetflixAPI.Models;

public class NetflixContext : DbContext
{
    public NetflixContext(DbContextOptions<NetflixContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; } = null!;
    public DbSet<Season> Season { get; set; } = null!;
    public DbSet<Episode> Episode { get; set; } = null!;
    public DbSet<WatchableContent> WatchableContent { get; set; } = null!;
    public DbSet<ContentType> ContentType { get; set; } = null!;
    public DbSet<Quality> Quality { get; set; } = null!;
    public DbSet<Genre> Genre { get; set; } = null!;
    public DbSet<SubtitleSettings> SubtitleSettings { get; set; } = null!;
    public DbSet<SubtitleContent> SubtitleContent { get; set; } = null!;

public DbSet<NetflixAPI.Models.WatchableContent> WatchableContent_1 { get; set; } = default!;

public DbSet<NetflixAPI.Models.Season> Season_1 { get; set; } = default!;

public DbSet<NetflixAPI.Models.Episode> Episode_1 { get; set; } = default!;

public DbSet<NetflixAPI.Models.SubtitleContent> SubtitleContent_1 { get; set; } = default!;
}