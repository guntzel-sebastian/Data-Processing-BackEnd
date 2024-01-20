using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(EpisodeId), nameof(QualityId))]
public class EpisodeXQualityAvailable
{
    public int EpisodeId { get; set; }
    public int QualityId { get; set; }

}