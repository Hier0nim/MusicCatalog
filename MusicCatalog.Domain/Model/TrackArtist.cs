using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Model
{
    public class TrackArtist
    {
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
