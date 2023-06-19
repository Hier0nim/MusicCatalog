namespace MusicCatalog.Application.ViewModels.Album;

public class ListAlbumForListVm
{
    public List<AlbumForListVm> Albums { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public string TitleSearchString { get; set; }
    public string ArtistSearchString { get; set; }
    public int YearSearchNumber { get; set; }
    public int Count { get; set; }
}