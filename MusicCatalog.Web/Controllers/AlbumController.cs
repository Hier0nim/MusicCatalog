using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MusicCatalog.Application.Interfaces;
using MusicCatalog.Application.ViewModels.Album;
using System.Security.Claims;

namespace MusicCatalog.Web.Controllers
{

    [Authorize(Roles = "Admin, User")]
    public class AlbumController : Controller
    {

        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public IActionResult Index(string sortOrder)
        {
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.YearSortParm = sortOrder == "date" ? "date_desc" : "date";
            ViewBag.ArtistSortParm = sortOrder == "artist" ? "artist_desc" : "artist";
            TempData["albumSortOrder"] = sortOrder;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = _albumService.GetAlbumsFromUserForList(2, 1, "", "", 0, userId, sortOrder);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNumber, string titleSearchString, string artistSearchString, int yearSearchNumber)
        {
            if (!pageNumber.HasValue)
            {
                pageNumber = 1;
            }
            titleSearchString ??= String.Empty;
            string sortOrder = TempData.ContainsKey("albumSortOrder") ? (string)TempData.Peek("albumSortOrder") : "";
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = _albumService.GetAlbumsFromUserForList(pageSize, pageNumber.Value, titleSearchString, artistSearchString, yearSearchNumber, userId, sortOrder);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditAlbum(int id)
        {
            var album = _albumService.GetAlbumForEdit(id);
            return View(album);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAlbum(NewAlbumVm model)
        {
            if (ModelState.IsValid)
            {
                _albumService.UpdateAlbum(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddAlbum()
        {
            return View(new NewAlbumVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAlbum(NewAlbumVm model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _albumService.AddAlbum(model, userId);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _albumService.DeleteAlbum(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id, string albumTitle, string artist)
        {
            TempData["selectedAlbum"] = id;
            TempData["AlbumTitle"] = albumTitle;
            TempData["Artist"] = artist;
            return RedirectToAction("Index", "Track");
        }
    }
}
