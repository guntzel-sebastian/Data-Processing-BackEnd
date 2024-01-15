using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(ProfileId), nameof(GenreId))]
public partial class ProfileXGenrePreference
{
    public ProfileXGenrePreference()
    {

    }

    public long ProfileId {get; set;}
    public long GenreId {get; set;}

}