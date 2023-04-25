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
    internal class TrackService : ITrackService
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
            throw new NotImplementedException();
        }

        public ListTrackForListVm GetAllTracksForList()
        {
            var tracks =  _trackRepo.GetAllTracks()
                .ProjectTo<TrackForListVm>(_mapper.ConfigurationProvider)
                .ToList();
            var trackList = new ListTrackForListVm()
            {
                Tracks = tracks,
                Count = tracks.Count
            };

            return trackList;
        }

        public TrackDetailsVm GetTrackDetails(int trackId)
        {
            var track = _trackRepo.GetTrackById(trackId);
            var trackVm = _mapper.Map<TrackDetailsVm>(track);

            trackVm.Artists = new List<ArtistForListVm>();
         
            foreach (var artist in track.TrackArtists)
            {
                var add = new ArtistForListVm()
                {
                    Id = artist.Artist.Id,
                    Name = artist.Artist.Name
                };
                trackVm.Artists.Add(add);

            } 
            return trackVm;
        }
    }
}
