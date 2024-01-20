using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(profile_id), nameof(language_id))]
public partial class SubtitleSettings
{
    public SubtitleSettings()
    {

    }

    public required long size {get; set;}
    public required string color {get; set;}
    public long profile_id {get; set;}
    public long language_id {get; set;}

}