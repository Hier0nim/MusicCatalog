using MusicCatalog.Application.ViewModels.Track;

namespace MusicCatalog.Application.Interfaces;

public interface ITrackService
{
    ListTrackForListVm GetTracksWithSpecificAlbumIdForList(int pageSize, int PageNumber, string searchString,
        int albumId, string sortOrder);

    int AddTrack(NewTrackVm track, int albumId);
    NewTrackVm GetTrackForEdit(int id);
    NewTrackVm UpdateTrack(NewTrackVm model);
    void DeleteTrack(int id);
}