using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(ProfileId), nameof(EpisodeId))]
public partial class ContentSession
{
    public ContentSession()
    {
    }

    public long ProfileId {get; set;}
    public long EpisodeId {get; set;}

    public bool Active {get; set;}
    public long LeftOffAt {get; set;}
    public long TimeWatched {get; set;}

}