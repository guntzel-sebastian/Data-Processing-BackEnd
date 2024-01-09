public partial class TextItem
{
    public TextItem()
    {
        TextItemXLanguages = new HashSet<TextItemXLanguage>();
    }

    public long TextItemId {get; set;}
    public string OnPageTextId {get; set;}

    public virtual ICollection<TextItemXLanguage> TextItemXLanguages {get; set;}
}