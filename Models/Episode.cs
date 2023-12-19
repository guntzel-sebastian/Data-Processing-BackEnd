namespace NetflixAPI.Models;

public class Episode
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required TimeSpan Duration { get; set; }
    public required HashSet<Quality> QualitySelection { get; set; }
}