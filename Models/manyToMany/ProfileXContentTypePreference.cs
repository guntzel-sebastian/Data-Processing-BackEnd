using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(ProfileId), nameof(ContentTypeId))]
public partial class ProfileXContentTypePreference
{
    public ProfileXContentTypePreference()
    {
    }

    public int ProfileId {get; set;}
    public int ContentTypeId {get; set;} // should be content type id

}