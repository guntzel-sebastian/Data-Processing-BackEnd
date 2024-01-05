public partial class ContentType
{
    public ContentType()
    {
        ProfileXContentTypePreferences = new HashSet<ProfileXContentTypePreference>();
        WatchableContents = new HashSet<WatchableContent>();
    }

    public long TextItemId {get; set;}
    public string Description {get; set;}

    public virtual ICollection<ProfileXContentTypePreference> ProfileXContentTypePreferences {get; set;}
    public virtual ICollection<WatchableContent> WatchableContents {get; set;}
}