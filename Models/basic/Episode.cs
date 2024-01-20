namespace NetflixAPI.Models;

public partial class Episode
{

    public Episode()
    {
    }
    
    public int Id { get; set; }
    public int ContentId { get; set; }
    public int SeasonId { get; set; }
    public required string EpisodeName { get; set; }
    public int ContentIndex { get; set; }
    public required int Length { get; set; }

    public virtual IList<int>? EpisodeQuality { get; set; }
    public virtual IList<int>? Subtitles { get; set; }
   
}
