namespace NetflixAPI.Models;

public class Quality
{
    public long Id { get; set; }
    public required string QualityName { get; set; }

    public virtual required ICollection<EpisodeXQualityAvailable> EpisodeQuality { get; set; }

}