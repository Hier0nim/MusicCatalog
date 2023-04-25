using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Application.Interfaces;
using MusicCatalog.Application.ViewModels.Track;
using MusicCatalog.Domain.Model;

namespace MusicCatalog.Web.Controllers
{
    public class TrackController : Controller
    {
        private readonly ITrackService _trackService;

        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        public IActionResult Index()
        {
            //create view
            //table with tracks
            //filter tracks
            //prepare data
            //transfer filter to service
            //service prepares
            //Service returns data in right format
            var model = _trackService.GetAllTracksForList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddTrack()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTrack(NewTrackVm model)
        {
            var id = _trackService.AddTrack(model);
            return View();
        }

        public IActionResult ViewTrack(int trackId)
        {
            var trackModel = _trackService.GetTrackDetails(trackId);
            return View(trackModel);
        }

    }

}
 