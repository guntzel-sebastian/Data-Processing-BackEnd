using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(content_id), nameof(classification_id))]
public class ContentXClassification
{
    public int content_id { get; set; }
    public int classification_id { get; set; }

}