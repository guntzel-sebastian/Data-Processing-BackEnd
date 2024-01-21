namespace NetflixAPI.Models;

public partial class Season
{

    public Season()
    {
    }

    public int season_id { get; set; }
    public required string director { get; set; }
    public required DateTime release_date { get; set; }

    
}