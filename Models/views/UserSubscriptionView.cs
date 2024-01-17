using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(SubscriptionId), nameof(UserId))]
public partial class UserSubscriptionView()
{

    public required long SubscriptionId {get; set;}
    public required string SubscriptionName {get; set;}
    public required double SubscriptionCost {get; set;}
	public required long QualityId {get; set;}
	public required long UserId {get; set;}
	public required string DateAcquired {get; set;}
	public required double PricePaid {get; set;}
	public required int DurationInDays {get; set;}

}