using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(profile_id), nameof(language_id))]
public partial class SubtitleSettings
{
    public SubtitleSettings()
    {

    }

    public required int size {get; set;}
    public required string color {get; set;}
    public int profile_id {get; set;}
    public int language_id {get; set;}

}