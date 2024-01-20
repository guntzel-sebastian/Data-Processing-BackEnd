using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(profile_id), nameof(content_type_id))]
public partial class ProfileXContentTypePreference
{
    public ProfileXContentTypePreference()
    {
    }

    public long profile_id {get; set;}
    public long content_type_id {get; set;}

}