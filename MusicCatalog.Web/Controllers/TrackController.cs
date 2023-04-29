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

        [HttpGet]
        public IActionResult Index()
        {
            var model = _trackService.GetAllTracksForList(2, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNumber, string searchString)
        {
            if (!pageNumber.HasValue)
            {
                pageNumber = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _trackService.GetAllTracksForList(pageSize, pageNumber.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditTrack(int id)
        {
            var track = _trackService.GetTrackForEdit(id);
            return View(track);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTrack(NewTrackVm model)
        {
            if (ModelState.IsValid)
            {
                _trackService.UpdateTrack(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddTrack()
        {
            return View(new NewTrackVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTrack(NewTrackVm model)
        {
            if (ModelState.IsValid)
            {
                var id = _trackService.AddTrack(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult ViewTrack(int trackId) 
        {
            var trackModel = _trackService.GetTrackDetails(trackId);
            return View(trackModel);
        }

        public IActionResult Delete(int id)
        {
            _trackService.DeleteTrack(id);
            return RedirectToAction("Index");
        }

    }

}
