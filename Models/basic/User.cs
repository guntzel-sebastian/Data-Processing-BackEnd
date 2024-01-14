namespace NetflixAPI.Models;

public partial class User
{
    public User()
    {
    }

    public long Id {get; set;}
    public required string EmailAddress {get; set;}
    public required string PasswordHash {get; set;}
    public bool? Activated {get; set;}
    public string? BlockedUntil {get; set;} // string, should probably be datetime (to prevent problems)
    public long? SubscriptionId {get; set;}
    public long? LanguageId {get; set;}
    public IList<long>? Profiles {get; set;}
    public IList<long>? FailedLoginAttempts {get; set;}
    public IList<long>? UserHasInvited {get; set;}
    public required bool UserHasBeenInvited {get; set;} // should probably not be a Collection (diagram error)

}