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

    public IList<long>? SubtitleSettings {get; set;}
    public IList<long>? ContentTypePreferences {get; set;}
    public IList<long>? GenrePreferences {get; set;}
    public IList<long>? ClassificationPreferences {get; set;}
    public IList<long>? WantToWatch {get; set;}
    public IList<long>? ContentSession {get; set;}

    
}