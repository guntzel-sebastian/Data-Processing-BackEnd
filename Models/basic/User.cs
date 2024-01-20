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
            using HttpResponseMessage response = await httpClient.GetAsync(this.EmailAddress);
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
        
        if(!IsEmailValid().Result)
        {
            return false;
        }

        return true;

    }

    public int Id {get; set;}
    public required string EmailAddress {get; set;}
    public required string PasswordHash {get; set;}
    public bool? Activated {get; set;}
    public string? BlockedUntil {get; set;} // string, should probably be datetime (to prevent problems)
    public int? SubscriptionId {get; set;}
    public int? LanguageId {get; set;}
    public IList<int>? Profiles {get; set;}
    public IList<int>? FailedLoginAttempts {get; set;}
    public IList<int>? UserHasInvited {get; set;}
    public required bool UserHasBeenInvited {get; set;} // should probably not be a Collection (diagram error)

}