namespace NetflixAPI.Models;

public partial class WatchableContent
{

    public WatchableContent()
    {
    }

    public long content_id { get; set; }
    public required string title { get; set; }
    public long CountryId { get; set; } 
    public required string release_date { get; set; }
    public required int age_rating { get; set; }
    public required string director { get; set; }
    public string? cover_image { get; set; }
    public long content_type_id { get; set; }

    public virtual IList<int>? Seasons { get; set; }
    public virtual IList<int>? Episodes { get; set; }
    public virtual IList<int>? Genres { get; set; }
    public virtual IList<int>? Classification { get; set; }
}