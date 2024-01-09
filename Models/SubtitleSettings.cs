namespace NetflixAPI.Models;

public class Subtitle
{
    public long Id { get; set; }
    public long profileId { get; set; }
    public long languageId { get; set; }
    public required string size { get; set; }
    public required string color { get; set; }

    public required Language Language { get; set; }
}