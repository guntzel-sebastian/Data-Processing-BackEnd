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
    public DbSet<Country> Country { get; set; } = null!;
    public DbSet<FailedLoginAttempt> FailedLoginAttempt { get; set; } = null!;
    public DbSet<Language> Language { get; set; } = null!;
    public DbSet<PersonalOffer> PersonalOffer { get; set; } = null!;
    public DbSet<Profile> Profile { get; set; } = null!;
    public DbSet<Subscription> Subscription { get; set; } = null!;
    public DbSet<TextItem> TextItem { get; set; } = null!;
    public DbSet<Classification> Classification { get; set; } = null!;
    public DbSet<APIKey> APIKey { get; set; } = null!;
    public DbSet<SubscriptionUserView> SubscriptionUserView { get; set; } = null!;
    public DbSet<GetTotalDailyRevenue> GetTotalDailyRevenue { get; set; } = null!;

public DbSet<NetflixAPI.Models.WatchableContent> WatchableContent_1 { get; set; } = default!;

public DbSet<NetflixAPI.Models.Season> Season_1 { get; set; } = default!;

public DbSet<NetflixAPI.Models.Episode> Episode_1 { get; set; } = default!;

public DbSet<NetflixAPI.Models.SubtitleContent> SubtitleContent_1 { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>().HasKey(x => x.country_id);
        modelBuilder.Entity<APIKey>().HasKey(x => x.api_key_id);
        modelBuilder.Entity<User>().HasKey(x => x.user_id);
        modelBuilder.Entity<Subscription>().HasKey(x => x.subscription_id);
        modelBuilder.Entity<Quality>().HasKey(x => x.quality_id);
        modelBuilder.Entity<Genre>().HasKey(x => x.genre_id);
        modelBuilder.Entity<Classification>().HasKey(x => x.classification_id);
        modelBuilder.Entity<WatchableContent>().HasKey(x => x.content_id);
        modelBuilder.Entity<Season>().HasKey(x => x.season_id);
        modelBuilder.Entity<Episode>().HasKey(x => x.episode_id);
        modelBuilder.Entity<Profile>().HasKey(x => x.profile_id);
        modelBuilder.Entity<FailedLoginAttempt>().HasKey(x => x.user_id);
        modelBuilder.Entity<Language>().HasKey(x => x.language_id);
        modelBuilder.Entity<TextItem>().HasKey(x => x.text_item_id);
        modelBuilder.Entity<ContentType>().HasKey(x => x.content_type_id);
        modelBuilder.Entity<SubtitleContent>().HasKey(x => x.subtitle_id);
        modelBuilder.Entity<GetTotalDailyRevenue>().HasNoKey();

        base.OnModelCreating(modelBuilder);
        modelBuilder
            .Entity<SubscriptionUserView>()
            .ToView("SubscriptionUserView");
    }
}