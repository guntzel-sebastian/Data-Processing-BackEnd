namespace NetflixAPI.Models;

public class Episode
{
    public long Id { get; set; }
    public long ContentId { get; set; }
    public long SeasonId { get; set; }
    public required string EpisodeName { get; set; }
    public int ContentIndex { get; set; }
    public required TimeSpan Length { get; set; }

    public virtual HashSet<EpisodeXQualityAvailable>? EpisodeQuality { get; set; }
    public virtual HashSet<SubtitleContent>? Subtitles { get; set; }
    public virtual required WatchableContent WatchableContent { get; set; }
    public virtual Season? Season { get; set; }
}
