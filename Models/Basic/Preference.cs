namespace NetflixAPI.Models;

public class Preferences
{
    public long Id { get; set; }
    public required HashSet<Genre> Genres { get; set; }
    public required HashSet<ContentType> ContentTypes { get; set; }
    public required HashSet<Classification> Classification { get; set; }
}