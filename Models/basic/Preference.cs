namespace NetflixAPI.Models;

public partial class Preference
{

    public Preference()
    {
    }

    public long Id { get; set; }
    public required HashSet<long> Genres { get; set; }
    public required HashSet<long> ContentTypes { get; set; }
    public required HashSet<long> Classifications { get; set; }
}