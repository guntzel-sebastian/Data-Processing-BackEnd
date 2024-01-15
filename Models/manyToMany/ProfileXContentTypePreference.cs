using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(ProfileId), nameof(ContentTypeId))]
public partial class ProfileXContentTypePreference
{
    public ProfileXContentTypePreference()
    {
    }

    public long ProfileId {get; set;}
    public long ContentTypeId {get; set;} // should be content type id

}