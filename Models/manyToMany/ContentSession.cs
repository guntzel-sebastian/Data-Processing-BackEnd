using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(ProfileId), nameof(EpisodeId))]
public partial class ContentSession
{
    public ContentSession()
    {
    }

    public int ProfileId {get; set;}
    public int EpisodeId {get; set;}

    public bool Active {get; set;}
    public int LeftOffAt {get; set;}
    public int TimeWatched {get; set;}

}