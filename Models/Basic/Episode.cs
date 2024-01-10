namespace NetflixAPI.Models;

public class Episode
{
    public long Id { get; set; }
    public long ContentId { get; set; }
    public long SeasonId { get; set; }
    public required string EpisodeName { get; set; }
    public int ContentIndex { get; set; }
    public required int Length { get; set; }

    
}
