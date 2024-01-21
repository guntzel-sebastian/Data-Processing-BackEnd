using System.ComponentModel.DataAnnotations;

namespace NetflixAPI.Models;

public partial class FailedLoginAttempt
{
    public FailedLoginAttempt()
    {
    }

    public int user_id {get; set;}
    public required DateTime date {get; set;}
    public required DateTime time {get; set;}

}