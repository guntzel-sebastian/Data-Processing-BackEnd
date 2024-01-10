using Microsoft.EntityFrameworkCore;

namespace NetflixAPI.Models;

[PrimaryKey(nameof(LanguageId), nameof(TextItemId))]
public partial class TextItemXLanguage
{
    public TextItemXLanguage()
    {

    }

    public long LanguageId {get; set;}
    public long TextItemId {get; set;}
    
}