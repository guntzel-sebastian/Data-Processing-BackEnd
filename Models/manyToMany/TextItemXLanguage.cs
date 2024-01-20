using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(LanguageId), nameof(TextItemId))]
public partial class TextItemXLanguage
{
    public TextItemXLanguage()
    {

    }

    public int LanguageId {get; set;}
    public int TextItemId {get; set;}
    
}