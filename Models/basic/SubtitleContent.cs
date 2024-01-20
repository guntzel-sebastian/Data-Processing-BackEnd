namespace NetflixAPI.Models;

public partial class SubtitleContent
{

    public SubtitleContent()
    {
    }

    public long subtitle_id { get; set; }
    public long episode_id { get; set; }
    public long language_id { get; set; }
    public required string subtitle_location { get; set; }

}