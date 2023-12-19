namespace NetflixAPI.Models;

public class WatchableContent
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required Country CountryOfProduction { get; set; }
    public required HashSet<Genre> Genres { get; set; }
    public required HashSet<Season> Seasons { get; set; }
    public required ContentType ContentType { get; set; }
    public required HashSet<Classification> Classifications { get; set; }
    public required HashSet<Subtitle> Subtitles { get; set; }
}