using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(user_id), nameof(invited_user_id))]
public partial class UserHasInvited
{
    public UserHasInvited()
    {

    }

    public long user_id {get; set;}
    public long invited_user_id {get; set;}
    public bool invited {get; set;}

}