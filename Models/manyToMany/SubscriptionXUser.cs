using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(SubscriptionId), nameof(UserId))]
public partial class SubscriptionXUser
{
    public SubscriptionXUser()
    {

    }

    public long SubscriptionId {get; set;}
    public long UserId {get; set;}

    public required string DateAquired {get; set;} // should be datetime
    public required double Duration {get; set;}
    public required double PricePaid {get; set;}

}