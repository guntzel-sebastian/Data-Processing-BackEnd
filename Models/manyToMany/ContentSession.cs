using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(profile_id), nameof(episode_id))]
public partial class ContentSession
{
    public ContentSession()
    {
    }

    public long profile_id {get; set;}
    public long episode_id {get; set;}

    public bool active {get; set;}
    public long left_off_at {get; set;}
    public long time_watched {get; set;}

}