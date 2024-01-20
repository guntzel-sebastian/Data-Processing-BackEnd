using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(language_id), nameof(text_item_id))]
public partial class TextItemXLanguage
{
    public TextItemXLanguage()
    {

    }

    public long language_id {get; set;}
    public long text_item_id {get; set;}

    // public string content {get; set;}
    
}