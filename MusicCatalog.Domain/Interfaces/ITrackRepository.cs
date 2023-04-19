using MusicCatalog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Interfaces
{
    public interface ITrackRepository
    {
        void DeleteTrack(int trackId);

        int AddTrack(Track track);

        IQueryable<Track> GetTracksByAlbumId(int albumId);

        IQueryable<Track> GetAllTracks();

        Track GetTrackById(int TrackId);

        IQueryable<Tag> GetAllTags();

    }
}
