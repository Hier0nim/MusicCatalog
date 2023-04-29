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
        ListTrackForListVm GetAllTracksForList(int pageSize, int PageNumber, string searchString);
        int AddTrack(NewTrackVm track);
        object GetTrackForEdit(int id);
        object UpdateTrack(NewTrackVm model);
        void DeleteTrack(int id);
    }
}
