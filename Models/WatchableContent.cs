namespace NetflixAPI.Models;

public class WatchableContent
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required Country CountryOfProduction { get; set; }
    public required DateTime ReleaseDate { get; set; }
    public required int AgeRating { get; set; }
    public required string Director { get; set; }
    public string CoverImage { get; set; }

    public virtual HashSet<Season> Seasons { get; set; }
    public virtual HashSet<Episode> Episodes { get; set; }
    public virtual HashSet<WatchableContentXGenres> WatchableContentXGenres { get; set; }
    public virtual HashSet<ContentXClassification> ContentXClassification { get; set; }
    public virtual ContentType ContentType { get; set; }
}