public partial class User
{
    public User()
    {
        Profiles = new HashSet<Profile>();
        FailedLoginAttempts = new HashSet<FailedLoginAttempt>();
        UserHasInvited = new HashSet<UserHasInvited>();
        UserHasBeenInvited = new HashSet<UserHasInvited>();
        SubscriptionXUsers = new HashSet<SubscriptionXUser>();
    }

    public long UserId {get; set;}

    public string EmailAddress {get; set;}

    public string PasswordHash {get; set;}

    public bool Activated {get; set;}

    public string BlockedUntil {get; set;} // string, should probably be datetime (to prevent problems)

    public long LanguageId {get; set;}

    public virtual ICollection<Profile> Profiles {get; set;}

    public virtual ICollection<FailedLoginAttempt> FailedLoginAttempts {get; set;}

    public virtual ICollection<UserHasInvited> UserHasInvited {get; set;}

    public virtual ICollection<UserHasInvited> UserHasBeenInvited {get; set;} // should probably not be a Collection (diagram error)

    public virtual ICollection<SubscriptionXUser> SubscriptionXUsers {get; set;}

}