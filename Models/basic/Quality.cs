public partial class Quality
{
    public Quality()
    {
        SubscriptionXQualityAlloweds = new HashSet<SubscriptionXQualityAllowed>();
        EpisodeXQualityAvailables = new HashSet<EpisodeXQualityAvailable>();
    }

    public long QualityId {get; set;}
    public string qualityName {get; set;}

    public virtual ICollection<SubscriptionXQualityAllowed> SubscriptionXQualityAlloweds {get; set;}
    public virtual ICollection<EpisodeXQualityAvailable> EpisodeXQualityAvailables {get; set;}
}