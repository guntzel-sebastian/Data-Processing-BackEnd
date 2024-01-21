using System.IO;

namespace NetflixAPI.Models;

public partial class WatchableContent : IValidator
{

    public WatchableContent()
    {
    }

    public int content_id { get; set; }
    public required string title { get; set; }
    public required string description { get; set; } 
    public required DateTime release_date { get; set; }
    public required int age_rating { get; set; }
    public int? episodes { get; set; }
    public required string director { get; set; }
    public required string cover_image { get; set; }
    public int content_type_id { get; set; }

    public bool Validate()
    {

        if(cover_image.IndexOfAny(Path.GetInvalidPathChars()) == -1)
        {
            return false;
        }

        return true;

    }
}