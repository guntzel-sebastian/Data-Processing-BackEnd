namespace NetflixAPI.Models;

public partial class Season
{

    public Season()
    {
    }

    public long Id { get; set; }
    public long ContentId { get; set; }
    public required string Director { get; set; }
    public required string ReleaseDate { get; set; }

    public virtual HashSet<long>? Episodes { get; set; }
    
}