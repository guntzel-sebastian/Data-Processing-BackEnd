public partial class ContentSession
{
    public ContentSession()
    {

    }

    public long ProfileId {get; set;}
    public long EpisodeId {get; set;}

    public bool Active {get; set;}
    public long LeftOffAt {get; set;}
    public long TimeWatched {get; set;}

    public virtual Profile Profile{get; set;}
    public virtual Episode Episode{get; set;}
}