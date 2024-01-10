namespace NetflixAPI.Models;

public partial class User
{
    public User()
    {
    }

    public long Id {get; set;}
    public required string EmailAddress {get; set;}
    public required string PasswordHash {get; set;}
    public required bool Activated {get; set;}
    public string? BlockedUntil {get; set;} // string, should probably be datetime (to prevent problems)
    public long SubscriptionId {get; set;}
    public required long LanguageId {get; set;}
    public virtual ICollection<long>? Profiles {get; set;}
    public virtual ICollection<long>? FailedLoginAttempts {get; set;}
    public virtual ICollection<long>? UserHasInvited {get; set;}
    public virtual required bool UserHasBeenInvited {get; set;} // should probably not be a Collection (diagram error)

}