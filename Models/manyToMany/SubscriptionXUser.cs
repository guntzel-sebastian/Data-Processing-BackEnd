public partial class SubscriptionXUser
{
    public SubscriptionXUser()
    {

    }

    public long SubscriptionId {get; set;}
    public long UserId {get; set;}

    public string dateAquired {get; set;} // should be datetime
    public double duration {get; set;}
    public double pricePaid {get; set;}

    public virtual Subscription Subscription{get; set;}
    public virtual User User{get; set;}

}