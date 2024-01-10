namespace NetflixAPI.Models;

public partial class Profile
{
    public Profile()
    {
    }

    public long ProfileId {get; set;}
    public long UserId {get; set;}
    public required string Name {get; set;}
    public string? Photo {get; set;}
    public required string DateOfBirth {get; set;} // made string for now to avoid potential server conflicts

    public ICollection<long>? SubtitleSettings {get; set;}
    public ICollection<long>? ContentTypePreferences {get; set;}
    public ICollection<long>? GenrePreferences {get; set;}
    public ICollection<long>? ClassificationPreferences {get; set;}
    public ICollection<long>? WantToWatch {get; set;}
    public ICollection<long>? ContentSession {get; set;}

    
}