using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(SubscriptionId), nameof(QualityId))]
public partial class SubscriptionXQualityAllowed
{
    public SubscriptionXQualityAllowed()
    {

    }

    public long SubscriptionId {get; set;}
    public long QualityId {get; set;}

}