namespace NetflixAPI.Models;

public partial class Subscription
{
    public Subscription()
    {
    }

    public int subscription_id {get; set;}
    public string? subscription_name {get; set;}

    public double? subscription_cost {get; set;}

    public required int quality_id {get; set;}
}