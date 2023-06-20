using AutoMapper;
using Moq;
using MusicCatalog.Application.Mapping;
using MusicCatalog.Application.Services;
using MusicCatalog.Application.ViewModels.Album;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Domain.Model;
using Serilog.Parsing;
using Xunit;

namespace MusicCatalog.Test.Track;

public class AlbumServiceTests
{
    private readonly Mock<IAlbumRepository> _albumRepositoryMock;
    private readonly IMapper _mapper;

    public AlbumServiceTests()
    {
        _albumRepositoryMock = new Mock<IAlbumRepository>();
        var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = mockMapper.CreateMapper();
    }

    [Fact]
    public void AddAlbum_ShouldReturnId()
    {
        // Arrange
        var albumService = new AlbumService(_albumRepositoryMock.Object, _mapper);
        var album = new NewAlbumVm
        {
            Id = 1,
            Title = "test"
        };
        _albumRepositoryMock.Setup(x => x.AddAlbum(It.IsAny<Domain.Model.Album>())).Returns(1);

        // Act
        var result = albumService.AddAlbum(album, "1");

        // Assert
        Assert.Equal(album.Id, result);
    }

    [Fact]
    public void DeleteAlbum_ShouldCallDeleteAlbumMethodOnce()
    {
        // Arrange
        var albumService = new AlbumService(_albumRepositoryMock.Object, _mapper);

        // Act
        albumService.DeleteAlbum(1);

        // Assert
        _albumRepositoryMock.Verify(x => x.DeleteAlbum(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void GetAlbumsForList_ShouldReturnListOfAlbums()
    {
        // Arrange
        var albumService = new AlbumService(_albumRepositoryMock.Object, _mapper);
        var albums = new List<Album>
        {
            new()
            {
                Id = 1,
                Artist = "",
                Title = "",
                Tracks = new List<Domain.Model.Track>(),
                PublicationYear = 1,
                Version = "",
                OwnerId = ""
            },
            new()
            {
                Id = 2,
                Artist = "",
                Title = "",
                Tracks = new List<Domain.Model.Track>(),
                PublicationYear = 1,
                Version = "",
                OwnerId = ""
            }
        };
        _albumRepositoryMock.Setup(x => x.GetAllAlbums())
            .Returns(albums.AsQueryable());

        // Act
        var result = albumService.GetAlbumsFromUserForList(2, 1, "", "", 1, "", "artist");

        // Assert
        Assert.Equal(2, result.Albums.Count());
    }

    [Fact]
    public void GetAlbumsForList_ShouldReturnListOfAlbumsFilteredByTitle()
    {
        // Arrange
        var albumService = new AlbumService(_albumRepositoryMock.Object, _mapper);
        var albums = new List<Album>
        {
            new()
            {
                Id = 1,
                Artist = "",
                Title = "test",
                Tracks = new List<Domain.Model.Track>(),
                PublicationYear = 1,
                Version = "",
                OwnerId = ""
            },
            new()
            {
                Id = 2,
                Artist = "",
                Title = "test2",
                Tracks = new List<Domain.Model.Track>(),
                PublicationYear = 1,
                Version = "",
                OwnerId = ""
            }
        };
        _albumRepositoryMock.Setup(x => x.GetAllAlbums())
            .Returns(albums.AsQueryable());

        // Act
        var result = albumService.GetAlbumsFromUserForList(2, 1, "test2", "", 1, "", "");

        // Assert
        Assert.Equal(1, result.Albums.Count());
    }

    [Fact]
    public void GetAlbumsForList_ShouldReturnListOfAlbumsFilteredByArtist()
    {
        // Arrange
        var albumService = new AlbumService(_albumRepositoryMock.Object, _mapper);
        var albums = new List<Album>
        {
            new()
            {
                Id = 1,
                Artist = "test",
                Title = "",
                Tracks = new List<Domain.Model.Track>(),
                PublicationYear = 1,
                Version = "",
                OwnerId = ""
            },
            new()
            {
                Id = 2,
                Artist = "test2",
                Title = "",
                Tracks = new List<Domain.Model.Track>(),
                PublicationYear = 1,
                Version = "",
                OwnerId = ""
            }
        };
        _albumRepositoryMock.Setup(x => x.GetAllAlbums())
            .Returns(albums.AsQueryable());

        // Act
        var result = albumService.GetAlbumsFromUserForList(2, 1, "", "test2", 1, "", "");

        // Assert
        Assert.Equal(1, result.Albums.Count());
    }

    [Fact]
    public void GetAlbumsForList_ShouldReturnListOfAlbumsFilteredByPublicationYear()
    {
        // Arrange
        var albumService = new AlbumService(_albumRepositoryMock.Object, _mapper);
        var albums = new List<Album>
        {
            new()
            {
                Id = 1,
                Artist = "",
                Title = "",
                Tracks = new List<Domain.Model.Track>(),
                PublicationYear = 1,
                Version = "",
                OwnerId = ""
            },
            new()
            {
                Id = 2,
                Artist = "",
                Title = "",
                Tracks = new List<Domain.Model.Track>(),
                PublicationYear = 2,
                Version = "",
                OwnerId = ""
            }
        };
        _albumRepositoryMock.Setup(x => x.GetAllAlbums())
            .Returns(albums.AsQueryable());

        // Act
        var result = albumService.GetAlbumsFromUserForList(2, 1, "", "", 2, "", "");

        // Assert
        Assert.Equal(1, result.Albums.Count());
    }


    [Fact]
    public void GetAlbumForEdit_ShouldReturnAlbum()
    {
        // Arrange
        var albumService = new AlbumService(_albumRepositoryMock.Object, _mapper);
        var album = new Album
        {
            Id = 1,
            Artist = "",
            Title = "",
            Tracks = new List<Domain.Model.Track>(),
            PublicationYear = 1,
            Version = "",
            OwnerId = ""
        };
        _albumRepositoryMock.Setup(x => x.GetAlbumById(It.IsAny<int>()))
            .Returns(album);

        // Act
        var result = albumService.GetAlbumForEdit(1);

        // Assert
        Assert.Equal(album.Id, result.Id);
    }

    [Fact]
    public void GetAlbumForEdit_ShouldReturnNull()
    {
        // Arrange
        var albumService = new AlbumService(_albumRepositoryMock.Object, _mapper);
        _albumRepositoryMock.Setup(x => x.GetAlbumById(It.IsAny<int>()))
            .Returns((Album)null);

        // Act
        var result = albumService.GetAlbumForEdit(1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpdateAlbum_ShouldReturnAlbum()
    {
        // Arrange
        var albumService = new AlbumService(_albumRepositoryMock.Object, _mapper);
        var album = new Album
        {
            Id = 1,
            Artist = "",
            Title = "",
            Tracks = new List<Domain.Model.Track>(),
            PublicationYear = 1,
            Version = "",
            OwnerId = ""
        };
        var albumVm = new NewAlbumVm()
        {
            Id = 1,
            Artist = "",
            Title = "",
            PublicationYear = 1,
            Version = "",
        };
        _albumRepositoryMock.Setup(x => x.UpdateAlbum(It.IsAny<Domain.Model.Album>()));

        // Act
        var result = albumService.UpdateAlbum(albumVm);

        // Assert
        Assert.Equal(album.Id, result.Id);
    }
}