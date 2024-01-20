using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(UserId), nameof(UserId_0))]
public partial class UserHasInvited
{
    public UserHasInvited()
    {

    }

    public int UserId {get; set;}
    public int UserId_0 {get; set;} // should be renamed to InvitedUserId 

}