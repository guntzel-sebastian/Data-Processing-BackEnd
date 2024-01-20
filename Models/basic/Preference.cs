namespace NetflixAPI.Models;

public partial class Preference
{

    public Preference()
    {
    }

    public int Id { get; set; }
    public required IList<int> Genres { get; set; }
    public required IList<int> ContentTypes { get; set; }
    public required IList<int> Classifications { get; set; }
}