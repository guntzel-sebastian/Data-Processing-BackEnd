namespace NetflixAPI.Models;

public partial class Subscription
{
    public Subscription()
    {
    }

    public long SubscriptionId {get; set;}
    public required string SubscriptionName {get; set;}

    public required float SubscriptionCost {get; set;}

    public virtual required ICollection<long> QualitiesAllowed {get; set;}
}