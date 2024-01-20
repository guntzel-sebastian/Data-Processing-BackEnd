namespace NetflixAPI.Models;

public partial class ContentType
{
    
    public ContentType()
    {
    }

    public long content_type_id {get; set;}
    public required string description {get; set;}
 
}