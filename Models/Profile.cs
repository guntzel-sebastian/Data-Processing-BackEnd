namespace NetflixAPI.Models;

public class Profile
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required Nationality Nationality { get; set; }
    public required string ProfileImage { get; set; }
    public required string Address { get; set; }
}