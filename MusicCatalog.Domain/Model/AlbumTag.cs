using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Model
{
    public class AlbumTag
    {
        public int AlbumId { get; set; }
        public Album Album{ get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
