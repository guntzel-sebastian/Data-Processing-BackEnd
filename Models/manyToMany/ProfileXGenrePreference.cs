public partial class ProfileXGenrePreference
{
    public ProfileXGenrePreference()
    {

    }

    public long ProfileId {get; set;}
    public long GenreId {get; set;}

    public virtual Profile Profile{get; set;}
    public virtual Genre Genre{get; set;}

}