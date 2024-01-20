namespace NetflixAPI.Models;

public partial class Genre
{
    public Genre()
    {
    }

    public int genre_id {get; set;}
    public required string genre {get; set;} // could make do with a rename to description

}