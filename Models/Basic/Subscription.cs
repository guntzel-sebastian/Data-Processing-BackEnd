namespace NetflixAPI.Models;

public class Subscription
{
    public long Id { get; set; }
    public required string Description { get; set; }
    public required Price Price { get; set; }
    public required HashSet<Quality> QualitySelection { get; set; }
    public required DateTime StartDate { get; set; }
    public required int Duration { get; set; }
}