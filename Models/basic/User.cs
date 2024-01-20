using Newtonsoft.Json;

namespace NetflixAPI.Models;

public partial class User : IValidator
{
    public User()
    {
    }

    private static readonly HttpClient httpClient = new()
    {
        BaseAddress = new Uri("https://www.disify.com/api/email/"),
    };

    public async Task<bool> IsEmailValid()
    {
        
        try
        {
            using HttpResponseMessage response = await httpClient.GetAsync(this.email);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic jsonResponse = JsonConvert.DeserializeObject(responseBody);
            return jsonResponse.format;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }

        return false;

    }

    public bool Validate()
    {
        
        if(IsEmailValid().Result)
        {
            return false;
        }



        return true;

    }

    public long user_id {get; set;}
    public required string email {get; set;}
    public required string password_hash {get; set;}
    public bool? activated {get; set;}
    public string? blocked_until {get; set;} // string, should probably be datetime (to prevent problems)
    public long? SubscriptionId {get; set;}
    public long? language_id {get; set;}
    public IList<long>? Profiles {get; set;}
    public IList<long>? FailedLoginAttempts {get; set;}
    public IList<long>? UserHasInvited {get; set;}
    public required bool UserHasBeenInvited {get; set;} // should probably not be a Collection (diagram error)

}