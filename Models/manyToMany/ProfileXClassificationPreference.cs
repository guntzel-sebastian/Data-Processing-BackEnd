using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(ProfileId), nameof(ClassificationId))]
public partial class ProfileXClassificationPreference
{
    public ProfileXClassificationPreference()
    {
    }

    public int ProfileId {get; set;}
    public int ClassificationId {get; set;}

}