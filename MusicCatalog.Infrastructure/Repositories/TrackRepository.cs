using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Infrastructure.Repositories
{
    public class TrackRepository
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


    }
}
