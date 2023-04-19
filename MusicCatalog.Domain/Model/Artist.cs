using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Model
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TrackArtist> TrackArtists { get; set; }
        public ICollection<AlbumArtist> AlbumArtists { get; set; }
    }
}
