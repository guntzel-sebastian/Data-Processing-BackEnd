namespace NetflixAPI.Models;

public partial class TextItem
{
    public TextItem()
    {
    }

    public long text_item_id {get; set;}
    public required string on_page_text_id {get; set;}

    public virtual required IList<long> Languages {get; set;}
}