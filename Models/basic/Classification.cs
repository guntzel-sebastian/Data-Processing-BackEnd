public partial class Classification
{
    public Classification()
    {
        ProfileXClassificationPreferences = new HashSet<ProfileXClassificationPreference>();
        ContentXClassifications = new HashSet<ContentXClassification>();
    }

    public long ClassificationId {get; set;}
    public int AgeRating {get; set;}

    public virtual ICollection<ProfileXClassificationPreference> ProfileXClassificationPreferences {get; set;}
    public virtual ICollection<ContentXClassification> ContentXClassifications {get; set;}
}