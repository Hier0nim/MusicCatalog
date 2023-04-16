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

        public void DeleteTrack(int trackId)
        {
            var track = _context.Tracks.Find(trackId);
            if (track != null)
            {
                _context.Tracks.Remove(track);
                _context.SaveChanges(); 
            }
        }

        public int AddTrack(Track track)
        {
            _context.Tracks.Add(track);
            _context.SaveChanges();
            return track.Id;
        }

        public IQueryable<Track> GetTracksByAlbumId(int albumId)
        {
            var tracks = _context.Tracks.Where(i => i.Album.Id == albumId);
            return tracks;
        }

        public Track GetTrackById(int TrackId) 
        {
            var track = _context.Tracks.FirstOrDefault(i => i.Id == TrackId);
            return track;
        }

        public IQueryable<Tag> GetAllTags()
        {
            var tags = _context.Tags;
            return tags;
        }

    }
}
