public partial class UserHasInvited
{
    public UserHasInvited()
    {

    }

    public long UserId {get; set;}
    public long UserId_0 {get; set;} // should be renamed to InvitedUserId 

    public virtual User User {get; set;}
    public virtual User InvitedUser {get; set;}
}