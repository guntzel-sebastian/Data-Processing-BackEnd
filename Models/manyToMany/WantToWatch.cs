using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(ProfileId), nameof(ContentId))]
public partial class WantToWatch
{
    public WantToWatch()
    {

    }

    public long ProfileId {get; set;}
    public long ContentId {get; set;}

    public bool Watched {get; set;}

}