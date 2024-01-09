public partial class Language
{
    public class Language()
    {
        TextItemXLanguages = new HashSet<TextItemXLanguage>();
    }

    public long LanguageId {get; set;}
    public string Language {get; set;}

    public User? User {get; set;} // likely incorrect

    public virtual ICollection<TextItemXLanguage> TextItemXLanguages {get; set;}
}