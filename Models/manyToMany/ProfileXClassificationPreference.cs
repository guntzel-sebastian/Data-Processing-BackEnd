using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(profile_id), nameof(classification_id))]
public partial class ProfileXClassificationPreference
{
    public ProfileXClassificationPreference()
    {
    }

    public long profile_id {get; set;}
    public long classification_id {get; set;}

}