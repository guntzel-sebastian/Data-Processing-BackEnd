namespace NetflixAPI.Models;

public class Subtitle
{
    public long Id { get; set; }
    public required Language Language { get; set; }
    public required Location SubtitleLocation { get; set; }
}