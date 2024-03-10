namespace NetflixAPI.Models;

public partial class Classification
{

    public Classification()
    {
    }

    public int classification_id {get; set;}
    public required string description {get; set;}
    public int? age_rating {get; set;}

}