using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(ProfileId), nameof(ClassificationId))]
public partial class ProfileXClassificationPreference
{
    public ProfileXClassificationPreference()
    {
    }

    public long ProfileId {get; set;}
    public long ClassificationId {get; set;}

}