namespace NetflixAPI.Models;

public partial class Profile
{
    public Profile()
    {
    }

    public int profile_id {get; set;}
    public int user_id {get; set;}
    public required string name {get; set;}
    public string? profile_image {get; set;}
    public required DateTime DateOfBirth {get; set;} 
    
}