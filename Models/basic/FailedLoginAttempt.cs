using System.ComponentModel.DataAnnotations;

namespace NetflixAPI.Models;

public partial class FailedLoginAttempt
{
    public FailedLoginAttempt()
    {
    }

    [Key]
    public long Id {get; set;}

    public long UserId {get; set;}
    public required string Date {get; set;} // should be datetime probably
    public required string Time {get; set;} // should be merged with datetime

}