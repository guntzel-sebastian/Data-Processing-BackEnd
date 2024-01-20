using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(profile_id), nameof(content_id))]
public partial class WantToWatch
{
    public WantToWatch()
    {

    }

    public int profile_id {get; set;}
    public int content_id {get; set;}

    public bool watched {get; set;}

}