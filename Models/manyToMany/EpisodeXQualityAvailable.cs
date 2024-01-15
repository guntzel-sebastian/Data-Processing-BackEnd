using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(EpisodeId), nameof(QualityId))]
public class EpisodeXQualityAvailable
{
    public long EpisodeId { get; set; }
    public long QualityId { get; set; }

}