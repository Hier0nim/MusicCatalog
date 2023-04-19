using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.ViewModels.Track
{
    public class TrackDetailsVm
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public DateTime DateCreated { get; set; }
        public List<ArtistForListVm> Artist { get; set; }
    }
}
