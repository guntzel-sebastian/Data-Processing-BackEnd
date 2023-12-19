namespace NetflixAPI.Models;

public class Season
{
    public long Id { get; set; }
    public required string Director { get; set; }
    public required DateTime ReleaseDate { get; set; }
    public required string Description { get; set; }
    public required string CoverImage { get; set; }
    public required HashSet<Episode> Episodes { get; set; }
}