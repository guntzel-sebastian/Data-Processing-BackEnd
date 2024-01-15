using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(UserId), nameof(UserId_0))]
public partial class UserHasInvited
{
    public UserHasInvited()
    {

    }

    public long UserId {get; set;}
    public long UserId_0 {get; set;} // should be renamed to InvitedUserId 

}