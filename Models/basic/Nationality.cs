namespace NetflixAPI.Models;

public partial class Nationality
{

    public Nationality()
    {
    }

    public int Id { get; set; }
    public required string Nation { get; set; }
}