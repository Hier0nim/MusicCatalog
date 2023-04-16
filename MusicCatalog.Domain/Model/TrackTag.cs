using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Model
{
    public class TrackTag
    {
        private int TrackId { get; set; }
        private Track Track{ get; set; }
        private int TagId { get; set; }
        private Tag Tag { get; set; }
    }
}
