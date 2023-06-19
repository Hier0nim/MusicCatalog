using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Application.Interfaces;
using MusicCatalog.Application.ViewModels.Track;

namespace MusicCatalog.Web.Controllers;

//[Authorize(Roles = "Admin, User")]
public class TrackController : Controller
{
    private readonly ITrackService _trackService;

    public TrackController(ITrackService trackService)
    {
        _trackService = trackService;
    }

    [HttpGet]
    public IActionResult Index(string sortOrder)
    {
        if (string.IsNullOrEmpty(sortOrder))
            ViewBag.TrackTitleSortParm = string.IsNullOrEmpty(sortOrder) ? "descending" : "ascending";
        else
            ViewBag.TrackTitleSortParm = sortOrder == "ascending" ? "descending" : "ascending";
        TempData["trackSortOrder"] = sortOrder;
        var selectedAlbumID = TempData.ContainsKey("selectedAlbum") ? (int)TempData.Peek("selectedAlbum") : -1;
        User.FindFirstValue(ClaimTypes.NameIdentifier);
        var model = _trackService.GetTracksWithSpecificAlbumIdForList(10, 1, "", selectedAlbumID, sortOrder);
        return View(model);
    }

    [HttpPost]
    public IActionResult Index(int pageSize, int? pageNumber, string searchString)
    {
        if (!pageNumber.HasValue) pageNumber = 1;
        searchString ??= string.Empty;
        var selectedAlbumID = TempData.ContainsKey("selectedAlbum") ? (int)TempData.Peek("selectedAlbum") : -1;
        var sortOrder = TempData.ContainsKey("trackSortOrder") ? (string)TempData.Peek("trackSortOrder") : "";
        var model = _trackService.GetTracksWithSpecificAlbumIdForList(pageSize, pageNumber.Value, searchString,
            selectedAlbumID, sortOrder);
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
            var selectedAlbumID = TempData.ContainsKey("selectedAlbum") ? (int)TempData.Peek("selectedAlbum") : -1;
            if (selectedAlbumID != -1)
            {
                _trackService.AddTrack(model, selectedAlbumID);
                return RedirectToAction("Index");
            }
        }

        return View(model);
    }

    public IActionResult Delete(int id)
    {
        _trackService.DeleteTrack(id);
        return RedirectToAction("Index");
    }
}