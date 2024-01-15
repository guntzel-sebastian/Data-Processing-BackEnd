namespace NetflixAPI.Models;

public partial class SubtitleContent
{

    public SubtitleContent()
    {
    }

    public long Id { get; set; }
    public long EpisodeId { get; set; }
    public long LanguageId { get; set; }
    public required string SubtitleLocation { get; set; }

}