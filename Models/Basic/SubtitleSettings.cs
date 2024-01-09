namespace NetflixAPI.Models;

public class Subtitle
{
    public long Id { get; set; }
    public long ProfileId { get; set; }
    public long LanguageId { get; set; }
    public required string Size { get; set; }
    public required string Color { get; set; }

    public required Language Language { get; set; }
}