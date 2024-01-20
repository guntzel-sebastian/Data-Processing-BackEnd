namespace NetflixAPI.Models;

public partial class Profile
{
    public Profile()
    {
    }

    public long profile_id {get; set;}
    public long user_id {get; set;}
    public required string name {get; set;}
    public string? profile_image {get; set;}
    public required DateTime DateOfBirth {get; set;} // made string for now to avoid potential server conflicts

    public IList<int>? SubtitleSettings {get; set;}
    public IList<int>? ContentTypePreferences {get; set;}
    public IList<int>? GenrePreferences {get; set;}
    public IList<int>? ClassificationPreferences {get; set;}
    public IList<int>? WantToWatch {get; set;}
    public IList<int>? ContentSession {get; set;}

    
}