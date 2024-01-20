using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(episode_id), nameof(quality_id))]
public class EpisodeXQualityAvailable
{
    public int episode_id { get; set; }
    public int quality_id { get; set; }

}