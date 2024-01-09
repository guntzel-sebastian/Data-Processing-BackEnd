public partial class WantToWatch
{
    public WantToWatch()
    {

    }

    public long ProfileId {get; set;}
    public long ContentId {get; set;}

    public bool watched {get; set;}

    public virtual Profile Profile{get; set;}
    public virtual Content Content{get; set;}

}