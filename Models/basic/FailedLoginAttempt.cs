using System.ComponentModel.DataAnnotations;

namespace NetflixAPI.Models;

public partial class FailedLoginAttempt
{
    public FailedLoginAttempt()
    {
    }

    [Key]
    public int Id {get; set;}

    public int UserId {get; set;}
    public required string Date {get; set;} // should be datetime probably
    public required string Time {get; set;} // should be merged with datetime

}