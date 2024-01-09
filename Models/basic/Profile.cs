public partial class Profile
{
    public Profile()
    {
        SubtitleSettings = new HashSet<SubtitleSettings>();

        ProfileXContentTypePreferences = new HashSet<ProfileXContentTypePreference>();

        ProfileXGenrePreferences = new HashSet<ProfileXGenrePreference>();

        ProfileXClassificationPreferences = new HashSet<ProfileXClassificationPreference>();

        WantToWatch = new HashSet<WantToWatch>();

        ContentSession = new HashSet<ContentSession>();
    }

    public long ProfileId {get; set;}

    public string Name {get; set;}

    public string Photo {get; set;}

    public string DateOfBirth {get; set;} // made string for now to avoid potential server conflicts

    public long UserId {get; set;}

    public virtual ICollection<SubtitleSettings> SubtitleSettings {get; set;}

    public virtual ICollection<ProfileXContentTypePreference> ProfileXContentTypePreferences {get; set;}

    public virtual ICollection<ProfileXGenrePreference> ProfileXGenrePreferences {get; set;}

    public virtual ICollection<ProfileXClassificationPreference> ProfileXClassificationPreferences {get; set;}

    public virtual ICollection<WantToWatch> WantToWatch {get; set;}

    public virtual ICollection<ContentSession> ContentSession {get; set;}

    
}