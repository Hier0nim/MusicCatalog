using MusicCatalog.Application.ViewModels.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.Interfaces
{
    public interface IAlbumService
    {
        ListAlbumForListVm GetAllAlbumsForList(int pageSize, int PageNumber, string searchString);
        int AddAlbum(NewAlbumVm album);
        object GetAlbumForEdit(int id);
        object UpdateAlbum(NewAlbumVm model);
        void DeleteAlbum(int id);
    }
}
