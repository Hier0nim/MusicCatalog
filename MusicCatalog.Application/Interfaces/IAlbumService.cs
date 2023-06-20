using MusicCatalog.Application.ViewModels.Album;

namespace MusicCatalog.Application.Interfaces;

public interface IAlbumService
{
    ListAlbumForListVm GetAlbumsFromUserForList(int pageSize, int PageNumber, string titleSearchString,
        string artistSearchString, int yearSearchNumber, string userId, string sortOrder);

    int AddAlbum(NewAlbumVm album, string userId);
    NewAlbumVm GetAlbumForEdit(int id);
    NewAlbumVm UpdateAlbum(NewAlbumVm model);
    void DeleteAlbum(int id);
}