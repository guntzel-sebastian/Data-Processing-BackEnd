namespace NetflixAPI.Models;

public partial class Nationality
{

    public Nationality()
    {
    }

    public long Id { get; set; }
    public required string Nation { get; set; }
}