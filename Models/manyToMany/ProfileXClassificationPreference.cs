public partial class ProfileXClassificationPreference
{
    public ProfileXClassificationPreference()
    {

    }

    public long ProfileId {get; set;}
    public long ClassificationId {get; set;}

    public virtual Profile Profile{get; set;}
    public virtual Classification Classification{get; set;}

}