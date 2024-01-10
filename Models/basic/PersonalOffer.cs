namespace NetflixAPI.Models;

public class PersonalOffer
{

    public PersonalOffer()
    {
    }

    public long Id { get; set; }
    public required HashSet<long> Content { get; set; }
}