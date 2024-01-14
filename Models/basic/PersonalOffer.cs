namespace NetflixAPI.Models;

public class PersonalOffer
{

    public PersonalOffer()
    {
    }

    public long Id { get; set; }
    public required IList<long> Content { get; set; }
}