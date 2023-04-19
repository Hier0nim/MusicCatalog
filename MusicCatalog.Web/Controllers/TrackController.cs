using Microsoft.AspNetCore.Mvc;

namespace MusicCatalog.Web.Controllers
{
    public class TrackController : Controller
    {
        public IActionResult Index()
        {
            //create view
            //table with tracks
            //filter tracks
            //prepare data
            //transfer filter to service
            //service prepares
            //Service returns data in right format
            var model = trackService.GetAllTracksForList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddTrack()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTrack(TrackModel model)
        {
            var id = trackService.AddTrack(model);
            return View();
        }

        public IActionResult ViewTrack(int trackId)
        {
            var trackModel = trackService.GetTrackDetails(trackId);
            return View(trackModel);
        }

    }

}
 