using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(WatchableContentId), nameof(GenreId))]
public class WatchableContentXGenres
{
    public long WatchableContentId { get; set; }
    public long GenreId { get; set; }

}