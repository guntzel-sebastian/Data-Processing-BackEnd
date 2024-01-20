namespace NetflixAPI.Models;

public partial class Classification
{

    public Classification()
    {
    }

    public int Id {get; set;}
    public required int AgeRating {get; set;}
    public required string Description {get; set;}

}