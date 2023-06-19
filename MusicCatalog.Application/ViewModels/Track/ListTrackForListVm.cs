namespace MusicCatalog.Application.ViewModels.Track;

public class ListTrackForListVm
{
    public List<TrackForListVm> Tracks { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public int Count { get; set; }
    public string AlbumTitle { get; set; }
    public string Artist { get; set; }
}