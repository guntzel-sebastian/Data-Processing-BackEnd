namespace NetflixAPI.Models;

public partial class Season
{

    public Season()
    {
    }

    public int Id { get; set; }
    public int ContentId { get; set; }
    public required string Director { get; set; }
    public required string ReleaseDate { get; set; }

    public virtual IList<int>? Episodes { get; set; }
    
}