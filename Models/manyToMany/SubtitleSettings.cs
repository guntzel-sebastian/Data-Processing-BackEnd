public partial class SubtitleSettings
{
    public SubtitleSettings()
    {

    }

    public long size {get; set;}
    public string color {get; set;}
    public long ProfileId {get; set;}

    public long languageId {get; set;}

    public virtual Language Language {get; set;}
    public virtual Profile Profile {get; set;}
}