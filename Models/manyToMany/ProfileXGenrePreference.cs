using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(ProfileId), nameof(GenreId))]
public partial class ProfileXGenrePreference
{
    public ProfileXGenrePreference()
    {

    }

    public int ProfileId {get; set;}
    public int GenreId {get; set;}

}