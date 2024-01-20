namespace NetflixAPI.Models;

public partial class TextItem
{
    public TextItem()
    {
    }

    public int Id {get; set;}
    public required string OnPageTextId {get; set;}

    public virtual required IList<int> Languages {get; set;}
}