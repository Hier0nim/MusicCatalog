using MusicCatalog.Domain.Model;

namespace MusicCatalog.Domain.Interfaces;

public interface IAlbumRepository
{
    void DeleteAlbum(int albumId);
    int AddAlbum(Album album);
    IQueryable<Album> GetAlbumByProviderId(int providerId);
    IQueryable<Album> GetAllAlbums();
    Album GetAlbumById(int albumId);
    void UpdateAlbum(Album album);
}