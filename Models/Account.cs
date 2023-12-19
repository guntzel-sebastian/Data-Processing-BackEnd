using System.Collections;

namespace NetflixAPI.Models;

public class Account
{
    public long Id { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string PaymentMethod { get; set; }
    public required HashSet<Account> InviteList { get; set; }
    public required Language Language { get; set; }
    public required Subscription Subscription { get; set; }
    public required HashSet<Profile> Profiles { get; set; }
    public required HashSet<WatchableContent> Watchlist { get; set; }
    public required Dictionary<WatchableContent, List<DateTime>> WatchHistory { get; set; }
    public bool Blocked { get; set; }
}