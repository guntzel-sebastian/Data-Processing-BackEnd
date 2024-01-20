namespace NetflixAPI.Models;

public partial class Classification
{

    public Classification()
    {
    }

    public long classification_id {get; set;}
    public required int age_rating {get; set;}

}