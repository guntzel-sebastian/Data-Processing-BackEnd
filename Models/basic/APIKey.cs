namespace NetflixAPI.Models;

public partial class APIKey
{

    public APIKey()
    {
    }

    public int Id {get; set;}
    public required string Key {get; set;}

}