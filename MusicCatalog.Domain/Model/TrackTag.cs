using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Model
{
    public class TrackTag
    {
        public int TrackId { get; set; }
        public Track Track{ get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
