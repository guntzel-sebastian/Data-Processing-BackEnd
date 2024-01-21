using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(subscription_id), nameof(user_id))]
public partial class SubscriptionUserView()
{

    public required int subscription_id {get; set;}
    public required string subscription_name {get; set;}
    public required double subscription_cost {get; set;}
	public required int user_id {get; set;}
	public required DateTime date_acquired {get; set;}
	public required double price_paid {get; set;}
	public required int duration_in_days {get; set;}

}