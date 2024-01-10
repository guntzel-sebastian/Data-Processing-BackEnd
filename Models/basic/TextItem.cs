namespace NetflixAPI.Models;

public partial class TextItem
{
    public TextItem()
    {
    }

    public long Id {get; set;}
    public required string OnPageTextId {get; set;}

    public virtual required ICollection<long> Languages {get; set;}
}