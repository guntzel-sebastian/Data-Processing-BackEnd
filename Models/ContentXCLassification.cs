using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(WatchableContentId), nameof(ClassificationId))]
public class ContentXClassification
{
    public long WatchableContentId { get; set; }
    public long ClassificationId { get; set; }

    public virtual required WatchableContent WatchableContent { get; set; }
    public virtual required Classification Classification { get; set; }
}