namespace NetflixAPI.Models;

public partial class Language
{
    public Language()
    {
    }

    public int Id {get; set;}
    public required string LanguageName {get; set;}

}