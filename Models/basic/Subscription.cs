namespace NetflixAPI.Models;

public partial class Subscription
{
    public Subscription()
    {
    }

    public long subscription_id {get; set;}
    public required string subscription_name {get; set;}

    public required float subscription_cost {get; set;}

    public virtual required IList<long> quality_id {get; set;}
}