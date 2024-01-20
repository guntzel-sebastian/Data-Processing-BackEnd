using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(content_id), nameof(classification_id))]
public class ContentXClassification
{
    public long content_id { get; set; }
    public long classification_id { get; set; }

}