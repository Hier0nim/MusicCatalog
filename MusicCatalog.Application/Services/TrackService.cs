using AutoMapper;
using AutoMapper.QueryableExtensions;
using MusicCatalog.Application.Interfaces;
using MusicCatalog.Application.ViewModels.Track;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.Services
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepo;
        private readonly IMapper _mapper;

        public TrackService(ITrackRepository trackRepo, IMapper mapper)
        {
            _trackRepo = trackRepo;
            _mapper = mapper; 
        }

        public int AddTrack(NewTrackVm track)
        {
            var tr = _mapper.Map<Track>(track);
            var id = _trackRepo.AddTrack(tr);
            return id;
        }

        public void DeleteTrack(int id)
        {
            _trackRepo.DeleteTrack(id);
        }

        public ListTrackForListVm GetAllTracksForList(int pageSize, int PageNumber, string searchString)
        {
            var tracks =  _trackRepo.GetAllTracks().Where(p => p.Title.StartsWith(searchString))
                .ProjectTo<TrackForListVm>(_mapper.ConfigurationProvider)
                .ToList();
            var tracksToShow = tracks.Skip(pageSize * (PageNumber - 1)).Take(pageSize).ToList();
            var trackList = new ListTrackForListVm()
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
}
