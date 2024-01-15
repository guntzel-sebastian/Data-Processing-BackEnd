using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(ProfileId), nameof(LanguageId))]
public partial class SubtitleSettings
{
    public SubtitleSettings()
    {

    }

    public required long Size {get; set;}
    public required string Color {get; set;}
    public long ProfileId {get; set;}
    public long LanguageId {get; set;}

}