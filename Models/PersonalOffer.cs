namespace NetflixAPI.Models;

public class PersonalOffer
{
    public long Id { get; set; }
    public required HashSet<WatchableContent> Content { get; set; }
}