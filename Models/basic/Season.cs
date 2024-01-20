namespace NetflixAPI.Models;

public partial class Season
{

    public Season()
    {
    }

    public long season_id { get; set; }
    public long content_id { get; set; }
    public required string director { get; set; }
    public required string release_date { get; set; }

    public virtual IList<long>? Episodes { get; set; }
    
}