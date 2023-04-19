using MusicCatalog.Application.ViewModels.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.Interfaces
{
    public interface ITrackService
    {
        ListTrackForListVm GetAllTracksForList();
        int AddTrack(NewTrackVm track);
        TrackDetailsVm GetTrackDetails(int trackId);
    }
}
