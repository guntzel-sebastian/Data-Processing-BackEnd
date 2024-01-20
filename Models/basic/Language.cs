namespace NetflixAPI.Models;

public partial class Language
{
    public Language()
    {
    }

    public long language_id {get; set;}
    public required string language {get; set;}

}