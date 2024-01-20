using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(profile_id), nameof(episode_id))]
public partial class ContentSession
{
    public ContentSession()
    {
    }

    public int profile_id {get; set;}
    public int episode_id {get; set;}

    public bool active {get; set;}
    public int left_off_at {get; set;}
    public int time_watched {get; set;}

}