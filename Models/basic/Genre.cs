namespace NetflixAPI.Models;

public partial class Genre
{
    public Genre()
    {
    }

    public long genre_id {get; set;}
    public required string genre {get; set;} // could make do with a rename to description

}