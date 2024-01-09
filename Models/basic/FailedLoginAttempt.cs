public partial class FailedLoginAttempt
{
    public FailedLoginAttempt()
    {
    }

    public long UserId;
    public string date; // should be datetime probably
    public string time; // should be merged with datetime

    public virtual User User {get; set;}
}