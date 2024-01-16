namespace NetflixAPI.Models;

public partial class APIKey
{

    public APIKey()
    {
    }

    public long Id {get; set;}
    public required string Key {get; set;}

}