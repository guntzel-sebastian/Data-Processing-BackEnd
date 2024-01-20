using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(profile_id), nameof(genre_id))]
public partial class ProfileXGenrePreference
{
    public ProfileXGenrePreference()
    {

    }

    public int profile_id {get; set;}
    public int genre_id {get; set;}

}