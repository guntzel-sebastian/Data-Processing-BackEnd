namespace NetflixAPI.Models;

public partial class FailedLoginAttempt
{
    public FailedLoginAttempt()
    {
    }

    public long Id;
    public long UserId;
    public required string Date; // should be datetime probably
    public required string Time; // should be merged with datetime

}