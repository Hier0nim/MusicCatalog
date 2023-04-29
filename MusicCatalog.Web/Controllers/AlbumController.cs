using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Application.Interfaces;
using MusicCatalog.Application.Services;
using MusicCatalog.Application.ViewModels.Album;

namespace MusicCatalog.Web.Controllers
{
    public class AlbumController : Controller
    {

        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _albumService.GetAllAlbumsForList(2, 1, "");
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
            var model = _albumService.GetAllAlbumsForList(pageSize, pageNumber.Value, searchString);
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
                var id = _albumService.AddAlbum(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _albumService.DeleteAlbum(id);
            return RedirectToAction("Index");
        }
    }
}
