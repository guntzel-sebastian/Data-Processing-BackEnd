public partial class Genre
{
    public Genre()
    {
        ProfileXGenrePreferences = new HashSet<ProfileXGenrePreference>();
        WatchableContentXGenres = new HashSet<WatchableContentXGenres>();
    }

    public long GenreId {get; set;}
    public string genre {get; set;} // could make do with a rename to description

    public virtual ICollection<ProfileXGenrePreference> ProfileXGenrePreferences {get; set;}
    public virtual ICollection<WatchableContentXGenres> WatchableContentXGenres {get; set;} // WatchableContentXGenres should be renamed to -genre
}