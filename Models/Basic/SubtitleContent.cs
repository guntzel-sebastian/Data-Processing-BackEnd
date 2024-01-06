namespace NetflixAPI.Models;

public class SubtitleContent
{
    public long Id { get; set; }
    public long EpisodeId { get; set; }
    public long LanguageId { get; set; }
    public required string SubtitleLocation { get; set; }

    public virtual required Episode Episode { get; set; }
    public virtual required Language Language { get; set; }
}