namespace NetflixAPI.Models;

public partial class Subtitle
{

    public Subtitle()
    {
    }

    public int Id { get; set; }
    public int ProfileId { get; set; }
    public int LanguageId { get; set; }
    public required string Size { get; set; }
    public required string Color { get; set; }

}