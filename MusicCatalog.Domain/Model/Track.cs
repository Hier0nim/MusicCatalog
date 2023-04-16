using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Model
{
    public class Track
    {
        private int Id { get; set; }
        private string Title { get; set; }
        private string Artist { get; set; }
        public virtual Album Album { get; set; }

        private ICollection<TrackTag> TrackTags { get; set; }
    }
}
