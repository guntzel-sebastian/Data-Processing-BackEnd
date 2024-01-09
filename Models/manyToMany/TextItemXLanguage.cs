public partial class TextItemXLanguage
{
    public TextItemXLanguage()
    {

    }

    public long LanguageId {get; set;}
    public string content {get; set;}
    public virtual TextItem TextItem{get; set;}
    public virtual Language Language{get; set;}
}