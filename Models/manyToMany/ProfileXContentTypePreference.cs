using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(profile_id), nameof(content_type_id))]
public partial class ProfileXContentTypePreference
{
    public ProfileXContentTypePreference()
    {
    }

    public int profile_id {get; set;}
    public int content_type_id {get; set;}

}