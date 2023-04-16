using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Model
{
    public class Album
    {
        private int Id { get; set; }
        private string Title { get; set; }
        private  string Artist{ get; set; }

        public virtual ICollection<Track> Tracks{ get;}
    }
}
