public partial class ProfileXContentTypePreference
{
    public ProfileXContentTypePreference()
    {

    }

    public long ProfileId {get; set;}
    public long ContentType {get; set;} // should be content type id

    public virtual Profile Profile{get; set;}
    public virtual ContentType ContentType{get; set;}

}