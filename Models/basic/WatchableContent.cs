namespace NetflixAPI.Models;

public partial class WatchableContent
{

    public WatchableContent()
    {
    }

    public int Id { get; set; }
    public required string Title { get; set; }
    public int CountryId { get; set; } 
    public required string ReleaseDate { get; set; }
    public required int AgeRating { get; set; }
    public required string Director { get; set; }
    public string? CoverImage { get; set; }
    public int ContentTypeId { get; set; }

    public virtual IList<int>? Seasons { get; set; }
    public virtual IList<int>? Episodes { get; set; }
    public virtual IList<int>? Genres { get; set; }
    public virtual IList<int>? Classification { get; set; }
}