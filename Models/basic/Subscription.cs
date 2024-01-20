namespace NetflixAPI.Models;

public partial class Subscription
{
    public Subscription()
    {
    }

    public int SubscriptionId {get; set;}
    public required string SubscriptionName {get; set;}

    public required float SubscriptionCost {get; set;}

    public virtual required IList<int> QualitiesAllowed {get; set;}
}