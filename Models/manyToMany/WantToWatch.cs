using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(ProfileId), nameof(ContentId))]
public partial class WantToWatch
{
    public WantToWatch()
    {

    }

    public int ProfileId {get; set;}
    public int ContentId {get; set;}

    public bool Watched {get; set;}

}