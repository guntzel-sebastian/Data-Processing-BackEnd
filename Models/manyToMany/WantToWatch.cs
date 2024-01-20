using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(profile_id), nameof(content_id))]
public partial class WantToWatch
{
    public WantToWatch()
    {

    }

    public long profile_id {get; set;}
    public long content_id {get; set;}

    public bool watched {get; set;}

}