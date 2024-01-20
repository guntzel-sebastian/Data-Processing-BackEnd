using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

public partial class Country
{

    public Country()
    {
    }

    public long country_id { get; set; }
    public required string Name { get; set; }
    
}