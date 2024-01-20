namespace NetflixAPI.Models;

public partial class Episode
{

    public Episode()
    {
    }
    
    public long episode_id { get; set; }
    public long content_id { get; set; }
    public long season_id { get; set; }
    public required string episode_name { get; set; }
    public int content_index { get; set; }
    public required int length { get; set; }

    public virtual IList<long>? episode_quality { get; set; }
    public virtual IList<long>? subtitles { get; set; }
   
}
