namespace NetflixAPI.Models;

public partial class Episode
{

    public Episode()
    {
    }
    
    public long Id { get; set; }
    public long ContentId { get; set; }
    public long SeasonId { get; set; }
    public required string EpisodeName { get; set; }
    public int ContentIndex { get; set; }
    public required int Length { get; set; }

    public virtual IList<long>? EpisodeQuality { get; set; }
    public virtual IList<long>? Subtitles { get; set; }
   
}
