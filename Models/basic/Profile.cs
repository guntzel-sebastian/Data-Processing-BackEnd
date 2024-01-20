namespace NetflixAPI.Models;

public partial class Profile
{
    public Profile()
    {
    }

    public int ProfileId {get; set;}
    public int UserId {get; set;}
    public required string Name {get; set;}
    public string? Photo {get; set;}
    public required string DateOfBirth {get; set;} // made string for now to avoid potential server conflicts

    public IList<int>? SubtitleSettings {get; set;}
    public IList<int>? ContentTypePreferences {get; set;}
    public IList<int>? GenrePreferences {get; set;}
    public IList<int>? ClassificationPreferences {get; set;}
    public IList<int>? WantToWatch {get; set;}
    public IList<int>? ContentSession {get; set;}

    
}