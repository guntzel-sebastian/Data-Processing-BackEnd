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

    public IList<long>? SubtitleSettings {get; set;}
    public IList<long>? ContentTypePreferences {get; set;}
    public IList<long>? GenrePreferences {get; set;}
    public IList<long>? ClassificationPreferences {get; set;}
    public IList<long>? WantToWatch {get; set;}
    public IList<long>? ContentSession {get; set;}

    
}