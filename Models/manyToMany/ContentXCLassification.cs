using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(WatchableContentId), nameof(ClassificationId))]
public class ContentXClassification
{
    public int WatchableContentId { get; set; }
    public int ClassificationId { get; set; }

}