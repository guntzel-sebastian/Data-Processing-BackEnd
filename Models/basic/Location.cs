namespace NetflixAPI.Models;

public partial class Location
{

    public Location()
    {
    }

    public int Id { get; set; }
    public required string Country { get; set; }

}