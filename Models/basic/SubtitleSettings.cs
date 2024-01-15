namespace NetflixAPI.Models;

public partial class Subtitle
{

    public Subtitle()
    {
    }

    public long Id { get; set; }
    public long ProfileId { get; set; }
    public long LanguageId { get; set; }
    public required string Size { get; set; }
    public required string Color { get; set; }

}