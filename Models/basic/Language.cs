namespace NetflixAPI.Models;

public partial class Language
{
    public Language()
    {
    }

    public long Id {get; set;}
    public required string LanguageName {get; set;}

}