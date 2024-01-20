using System.ComponentModel.DataAnnotations;

namespace NetflixAPI.Models;

public partial class FailedLoginAttempt
{
    public FailedLoginAttempt()
    {
    }

    public int user_id {get; set;}
    public required string date {get; set;} // should be datetime probably
    public required string time {get; set;} // should be merged with datetime

}