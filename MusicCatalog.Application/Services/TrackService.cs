using AutoMapper;
using AutoMapper.QueryableExtensions;
using MusicCatalog.Application.Interfaces;
using MusicCatalog.Application.ViewModels.Track;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Domain.Model;

namespace MusicCatalog.Application.Services;

public class TrackService : ITrackService
{
    private readonly IMapper _mapper;
    private readonly ITrackRepository _trackRepo;

    public TrackService(ITrackRepository trackRepo, IMapper mapper)
    {
        _trackRepo = trackRepo;
        _mapper = mapper;
    }

    public int AddTrack(NewTrackVm track, int albumId)
    {
        var tr = _mapper.Map<Track>(track);
        tr.AlbumId = albumId;
        var id = _trackRepo.AddTrack(tr);
        return id;
    }

    public void DeleteTrack(int id)
    {
        _trackRepo.DeleteTrack(id);
    }

    public ListTrackForListVm GetTracksWithSpecificAlbumIdForList(int pageSize, int PageNumber, string searchString,
        int albumId, string sortOrder)
    {
        var tracks = _trackRepo.GetAllTracks().Where(p => p.Title.StartsWith(searchString))
            .Where(p => p.Album.Id == albumId)
            .ProjectTo<TrackForListVm>(_mapper.ConfigurationProvider)
            .ToList();
        switch (sortOrder)
        {
            case "descending":
                tracks = tracks.OrderByDescending(o => o.Title).ToList();
                break;
            case "ascending":
                tracks = tracks.OrderBy(o => o.Title).ToList();
                break;
        }

        var tracksToShow = tracks.Skip(pageSize * (PageNumber - 1)).Take(pageSize).ToList();
        var trackList = new ListTrackForListVm
        {
            PageSize = pageSize,
            CurrentPage = PageNumber,
            SearchString = searchString,
            Tracks = tracksToShow,
            Count = tracks.Count
        };
        return trackList;
    }

    public object GetTrackForEdit(int id)
    {
        var track = _trackRepo.GetTrackById(id);
        var trackVm = _mapper.Map<NewTrackVm>(track);
        return trackVm;
    }

    public object UpdateTrack(NewTrackVm model)
    {
        var track = _mapper.Map<Track>(model);
        _trackRepo.UpdateTrack(track);
        return model;
    }
}