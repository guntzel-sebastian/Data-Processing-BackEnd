public partial class SubscriptionXQualityAllowed
{
    public SubscriptionXQualityAllowed()
    {

    }

    public long SubscriptionId {get; set;}
    public long QualityId {get; set;}

    public virtual Subscription Subscription{get; set;}
    public virtual Quality Quality{get; set;}

}