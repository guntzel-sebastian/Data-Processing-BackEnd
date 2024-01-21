namespace NetflixAPI.Models;

public partial class APIKey
{

    public APIKey()
    {
    }

    public int api_key_id {get; set;}
    public required string api_key_hash {get; set;}

}