using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(ProfileId), nameof(LanguageId))]
public partial class SubtitleSettings
{
    public SubtitleSettings()
    {

    }

    public required int Size {get; set;}
    public required string Color {get; set;}
    public int ProfileId {get; set;}
    public int LanguageId {get; set;}

}