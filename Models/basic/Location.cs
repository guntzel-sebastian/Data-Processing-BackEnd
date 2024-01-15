namespace NetflixAPI.Models;

public partial class Location
{

    public Location()
    {
    }

    public long Id { get; set; }
    public required string Country { get; set; }

}