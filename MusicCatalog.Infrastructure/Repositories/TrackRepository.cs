using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Infrastructure.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly Context _context;
        public TrackRepository(Context context) 
        { 
            _context = context;
        }

        public int AddTrack(Track track)
        {
            _context.Tracks.Add(track);
            _context.SaveChanges();
            return track.Id;
        }

        public void DeleteTrack(int trackId)
        {
            var track = _context.Tracks.Find(trackId);
            if (track != null)
            {
                _context.Tracks.Remove(track);
                _context.SaveChanges(); 
            }
        }
        public Track GetTrackById(int trackId)
        {
            var track = _context.Tracks.FirstOrDefault(i => i.Id == trackId);
            return track;
        }

        public IQueryable<Track> GetTracksByAlbumId(int albumId)
        {
            var tracks = _context.Tracks.Where(i => i.Album.Id == albumId);
            return tracks;
        }

        public IQueryable<Track> GetAllTracks()
        {
            var tracks = _context.Tracks;
            return tracks;
        }

        public void UpdateTrack(Track track)
        {
            _context.Attach(track);
            _context.Entry(track).Property("Title").IsModified = true;
            _context.Entry(track).Property("Length").IsModified = true;
            _context.SaveChanges();
        }
    }
}
