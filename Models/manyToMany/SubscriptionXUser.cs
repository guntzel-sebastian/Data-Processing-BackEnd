using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(subscription_id), nameof(user_id))]
public partial class SubscriptionXUser
{
    public SubscriptionXUser()
    {

    }

    public int subscription_id {get; set;}
    public int user_id {get; set;}

    public required string date_acquired {get; set;} // should be datetime
    public required double duration_in_days {get; set;}
    public required double price_paid {get; set;}

}