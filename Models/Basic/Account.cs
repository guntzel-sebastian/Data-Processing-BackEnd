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
    public virtual HashSet<Profile>? Profiles { get; set; }
    public bool Blocked { get; set; }
}