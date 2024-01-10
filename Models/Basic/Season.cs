namespace NetflixAPI.Models;

public class Season
{
    public long Id { get; set; }
    public long ContentId { get; set; }
    public required string Director { get; set; }
    public required DateTime ReleaseDate { get; set; }

    public virtual HashSet<Episode>? Episodes { get; set; }
    public virtual required WatchableContent WatchableContent { get; set; }
}