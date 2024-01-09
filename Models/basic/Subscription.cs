public partial class Subscription
{
    public Subscription()
    {
        SubscriptionXUsers = new HashSet<SubscriptionXUser>();
        SubscriptionXQualityAllowed = new HashSet<SubscriptionXQualityAllowed>();
    }

    public long SubscriptionId {get; set;}
    public string SubscriptionName {get; set;}

    public float SubscriptionCost {get; set;}

    public virtual ICollection<SubscriptionXUser> SubscriptionXUsers {get; set;}

    public virtual ICollection<SubscriptionXQualityAllowed> SubscriptionXQualityAlloweds {get; set;}
}