using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Model
{
    public class AlbumArtist
    {
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
