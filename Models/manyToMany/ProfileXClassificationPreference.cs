using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(profile_id), nameof(classification_id))]
public partial class ProfileXClassificationPreference
{
    public ProfileXClassificationPreference()
    {
    }

    public int profile_id {get; set;}
    public int classification_id {get; set;}

}