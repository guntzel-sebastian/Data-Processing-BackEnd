namespace NetflixAPI.Models;

public partial class TextItem
{
    public TextItem()
    {
    }

    public int text_item_id {get; set;}
    public required string on_page_text_id {get; set;}

}