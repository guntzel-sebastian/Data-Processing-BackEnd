namespace NetflixAPI.Models;

public partial class Season
{

    public Season()
    {
    }

    public int season_id { get; set; }
    public int content_id { get; set; }
    public required string director { get; set; }
    public required string release_date { get; set; }

    public virtual IList<int>? Episodes { get; set; }
    
}