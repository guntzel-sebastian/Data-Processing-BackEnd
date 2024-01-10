namespace NetflixAPI.Models;

public partial class Country
{

    public Country()
    {
    }

    public long Id { get; set; }
    public required string Name { get; set; }
    
}