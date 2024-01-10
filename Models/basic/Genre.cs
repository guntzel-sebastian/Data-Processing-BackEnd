namespace NetflixAPI.Models;

public partial class Genre
{
    public Genre()
    {
    }

    public long Id {get; set;}
    public required string GenreName {get; set;} // could make do with a rename to description

}