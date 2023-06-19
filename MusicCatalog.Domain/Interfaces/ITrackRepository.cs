using MusicCatalog.Domain.Model;

namespace MusicCatalog.Domain.Interfaces;

public interface ITrackRepository
{
    void DeleteTrack(int trackId);
    int AddTrack(Track track);
    IQueryable<Track> GetTracksByAlbumId(int albumId);
    IQueryable<Track> GetAllTracks();
    Track GetTrackById(int trackId);
    void UpdateTrack(Track track);
}