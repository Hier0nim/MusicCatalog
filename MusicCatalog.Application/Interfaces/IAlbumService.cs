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
        ListAlbumForListVm GetAlbumsFromUserForList(int pageSize, int PageNumber, string titleSearchString,string artistSearchString, int yearSearchNumber, string userId, string sortOrder);
        int AddAlbum(NewAlbumVm album, string userId);
        object GetAlbumForEdit(int id);
        object UpdateAlbum(NewAlbumVm model);
        void DeleteAlbum(int id);
    }
}
