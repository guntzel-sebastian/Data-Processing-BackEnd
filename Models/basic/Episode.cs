namespace NetflixAPI.Models;

public partial class Episode
{

    public Episode()
    {
    }
    
    public int episode_id { get; set; }
    public int content_id { get; set; }
    public int season_id { get; set; }
    public required string episode_name { get; set; }
    public int content_index { get; set; }
    public required int length { get; set; }

}
