namespace NetflixAPI.Models;

public partial class SubtitleContent
{

    public SubtitleContent()
    {
    }

    public int Id { get; set; }
    public int EpisodeId { get; set; }
    public int LanguageId { get; set; }
    public required string SubtitleLocation { get; set; }

}