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

        public int AddTrack(NewTrackVm track)
        {
            throw new NotImplementedException();
        }

        public ListTrackForListVm GetAllTracksForList()
        {
            var tracks =  _trackRepo.GetAllTracks();
            ListTrackForListVm result = new()
            {
                Tracks = new List<TrackForListVm>()
            };
            foreach (var track in tracks)
            {
                var trackVm = new TrackForListVm()
                {
                    Id = track.Id,
                    Title = track.Title
                };
                result.Tracks.Add(trackVm);
                  
            }
            result.Count = result.Tracks.Count;
            return result;
        }

        public TrackDetailsVm GetTrackDetails(int trackId)
        {
            var track = _trackRepo.GetTrackById(trackId);
            var trackVm = new TrackDetailsVm
            {
                Id = trackId,
                Length = trackId,
                Artist = new List<ArtistForListVm>()
            };

            foreach (var artist in track.TrackArtists)
            {
                var add = new ArtistForListVm()
                {
                    Id = artist.Artist.Id,
                    Name = artist.Artist.Name
                };
                trackVm.Artist.Add(add);

            }
            return trackVm;
        }
    }
}
