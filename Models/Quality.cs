namespace NetflixAPI.Models;

public class Quality
{
    public long Id { get; set; }
    public string? QualityName { get; set; }
    public required int Horizontal { get; set; }
    public required int Vertical { get; set; }
}