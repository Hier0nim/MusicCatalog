using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Model
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Album Album { get; set; }

        public ICollection<TrackTag> TrackTags { get; set; }
        public ICollection<TrackArtist> TrackArtists{ get; set; }
    }
}
 