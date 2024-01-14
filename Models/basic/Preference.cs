namespace NetflixAPI.Models;

public partial class Preference
{

    public Preference()
    {
    }

    public long Id { get; set; }
    public required IList<long> Genres { get; set; }
    public required IList<long> ContentTypes { get; set; }
    public required IList<long> Classifications { get; set; }
}