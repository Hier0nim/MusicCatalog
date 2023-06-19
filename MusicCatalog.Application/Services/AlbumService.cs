using AutoMapper;
using AutoMapper.QueryableExtensions;
using MusicCatalog.Application.Interfaces;
using MusicCatalog.Application.ViewModels.Album;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Domain.Model;

namespace MusicCatalog.Application.Services;

internal class AlbumService : IAlbumService
{
    private readonly IAlbumRepository _albumRepo;
    private readonly IMapper _mapper;

    public AlbumService(IAlbumRepository albumRepo, IMapper mapper)
    {
        _albumRepo = albumRepo;
        _mapper = mapper;
    }

    public int AddAlbum(NewAlbumVm album, string userId)
    {
        var alb = _mapper.Map<Album>(album);
        alb.OwnerId = userId;
        var id = _albumRepo.AddAlbum(alb);
        return id;
    }

    public void DeleteAlbum(int id)
    {
        _albumRepo.DeleteAlbum(id);
    }

    public ListAlbumForListVm GetAlbumsFromUserForList(int pageSize, int PageNumber, string titleSearchString,
        string artistSearchString, int yearSearchNumber, string userId, string sortOrder)
    {
        List<AlbumForListVm> albums;
        titleSearchString ??= "";
        artistSearchString ??= "";
        if (yearSearchNumber != 0)
            albums = _albumRepo.GetAllAlbums().Where(p => p.Title.StartsWith(titleSearchString))
                .Where(p => p.Artist.StartsWith(artistSearchString))
                .Where(p => p.PublicationYear.Equals(yearSearchNumber))
                .Where(p => p.OwnerId == userId)
                .ProjectTo<AlbumForListVm>(_mapper.ConfigurationProvider)
                .ToList();
        else
            albums = _albumRepo.GetAllAlbums().Where(p => p.Title.StartsWith(titleSearchString))
                .Where(p => p.Artist.StartsWith(artistSearchString))
                .Where(p => p.OwnerId == userId)
                .ProjectTo<AlbumForListVm>(_mapper.ConfigurationProvider)
                .ToList();

        albums = sortOrder switch
        {
            "title_desc" => albums.OrderByDescending(o => o.Title).ToList(),
            "date" => albums.OrderBy(o => o.PublicationYear).ToList(),
            "date_desc" => albums.OrderByDescending(o => o.PublicationYear).ToList(),
            "artist" => albums.OrderBy(o => o.Artist).ToList(),
            "artist_desc" => albums.OrderByDescending(o => o.Artist).ToList(),
            _ => albums.OrderBy(o => o.Title).ToList()
        };
        var albumsToShow = albums.Skip(pageSize * (PageNumber - 1)).Take(pageSize).ToList();
        var albumList = new ListAlbumForListVm
        {
            PageSize = pageSize,
            CurrentPage = PageNumber,
            TitleSearchString = titleSearchString,
            ArtistSearchString = artistSearchString,
            YearSearchNumber = yearSearchNumber,
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