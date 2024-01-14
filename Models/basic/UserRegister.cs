namespace NetflixAPI.Models;

public partial class UserRegister
{
    public UserRegister()
    {
    }

    public required string EmailAddress {get; set;}
    public required string Password {get; set;}
    public virtual required bool UserHasBeenInvited {get; set;} // should probably not be a Collection (diagram error)

}