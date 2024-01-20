namespace NetflixAPI.Models;

public partial class SubtitleContent
{

    public SubtitleContent()
    {
    }

    public int subtitle_id { get; set; }
    public int episode_id { get; set; }
    public int language_id { get; set; }
    public required string subtitle_location { get; set; }

}