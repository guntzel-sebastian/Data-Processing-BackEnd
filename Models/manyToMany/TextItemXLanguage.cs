using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(language_id), nameof(text_item_id))]
public partial class TextItemXLanguage
{
    public TextItemXLanguage()
    {

    }

    public int language_id {get; set;}
    public int text_item_id {get; set;}

    // public string content {get; set;}
    
}