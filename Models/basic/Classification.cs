namespace NetflixAPI.Models;

public partial class Classification
{

    public Classification()
    {
    }

    public long Id {get; set;}
    public required int AgeRating {get; set;}

}