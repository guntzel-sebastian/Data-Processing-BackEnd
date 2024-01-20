using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(episode_id), nameof(quality_id))]
public class EpisodeXQualityAvailable
{
    public long episode_id { get; set; }
    public long quality_id { get; set; }

}