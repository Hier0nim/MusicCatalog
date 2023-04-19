using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.ViewModels.Track
{
    public class ListTrackForListVm
    {
        public List<TrackForListVm> Tracks { get; set; }
        public int Count { get; set; }
    }
}
