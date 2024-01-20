namespace NetflixAPI.Models;

public partial class Price
{

    public Price()
    {
    }

    public int Id { get; set; }
    public required double Value { get; set; }
}