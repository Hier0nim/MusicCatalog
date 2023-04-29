using AutoMapper;
using AutoMapper.QueryableExtensions;
using MusicCatalog.Application.Interfaces;
using MusicCatalog.Application.ViewModels.Album;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.Services
{
    internal class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepo;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepo, IMapper mapper)
        {
            _albumRepo = albumRepo;
            _mapper = mapper;
        }

        public int AddAlbum(NewAlbumVm album)
        {
            var alb = _mapper.Map<Album>(album);
            var id = _albumRepo.AddAlbum(alb);
            return id;
        }

        public void DeleteAlbum(int id)
        {
            _albumRepo.DeleteAlbum(id);
        }

        public ListAlbumForListVm GetAllAlbumsForList(int pageSize, int PageNumber, string searchString)
        {
            var albums = _albumRepo.GetAllAlbums().Where(p => p.Title.StartsWith(searchString))
                .ProjectTo<AlbumForListVm>(_mapper.ConfigurationProvider)
                .ToList();
            var albumsToShow = albums.Skip(pageSize * (PageNumber - 1)).Take(pageSize).ToList();
            var albumList = new ListAlbumForListVm()
            {
                PageSize = pageSize,
                CurrentPage = PageNumber,
                SearchString = searchString,
                Albums = albumsToShow,
                Count = albums.Count
            };

            return albumList;
        }

        public object GetAlbumForEdit(int id)
        {
            var album = _albumRepo.GetAlbumById(id);
            var albumVm = _mapper.Map<NewAlbumVm>(album);
            return albumVm;
        }


        public object UpdateAlbum(NewAlbumVm model)
        {
            var album = _mapper.Map<Album>(model);
            _albumRepo.UpdateAlbum(album);
            return model;
        }
    }
}
