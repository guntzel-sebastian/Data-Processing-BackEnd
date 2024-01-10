namespace NetflixAPI.Models;

public partial class WatchableContent
{

    public WatchableContent()
    {
    }

    public long Id { get; set; }
    public required string Title { get; set; }
    public long CountryId { get; set; } 
    public required string ReleaseDate { get; set; }
    public required int AgeRating { get; set; }
    public required string Director { get; set; }
    public string? CoverImage { get; set; }
    public long ContentTypeId { get; set; }

    public virtual HashSet<long>? Seasons { get; set; }
    public virtual HashSet<long>? Episodes { get; set; }
    public virtual HashSet<long>? Genres { get; set; }
    public virtual HashSet<long>? Classification { get; set; }
}