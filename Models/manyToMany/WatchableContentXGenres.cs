using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(WatchableContentId), nameof(GenreId))]
public class WatchableContentXGenres
{
    public int WatchableContentId { get; set; }
    public int GenreId { get; set; }

}