using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(SubscriptionId), nameof(QualityId))]
public partial class SubscriptionXQualityAllowed
{
    public SubscriptionXQualityAllowed()
    {

    }

    public int SubscriptionId {get; set;}
    public int QualityId {get; set;}

}