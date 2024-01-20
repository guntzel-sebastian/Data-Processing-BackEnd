namespace NetflixAPI.Models;

public class PersonalOffer
{

    public PersonalOffer()
    {
    }

    public int Id { get; set; }
    public required IList<int> Content { get; set; }
}