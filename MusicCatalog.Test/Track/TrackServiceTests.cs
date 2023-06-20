using AutoMapper;
using Moq;
using MusicCatalog.Application.Mapping;
using MusicCatalog.Application.Services;
using MusicCatalog.Application.ViewModels.Track;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Domain.Model;
using Xunit;

namespace MusicCatalog.Test.Track;

public class TrackServiceTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ITrackRepository> _trackRepositoryMock;

    public TrackServiceTests()
    {
        _trackRepositoryMock = new Mock<ITrackRepository>();
        var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = mockMapper.CreateMapper();
    }

    [Fact]
    public void AddTrack_ShouldReturnId()
    {
        // Arrange
        var trackService = new TrackService(_trackRepositoryMock.Object, _mapper);
        var track = new NewTrackVm
        {
            Id = 1,
            Title = "test"
        };
        _trackRepositoryMock.Setup(x => x.AddTrack(It.IsAny<Domain.Model.Track>())).Returns(1);

        // Act
        var result = trackService.AddTrack(track, 1);

        // Assert
        Assert.Equal(track.Id, result);
    }

    [Fact]
    public void DeleteTrack_ShouldCallDeleteTrackMethodOnce()
    {
        // Arrange
        var trackService = new TrackService(_trackRepositoryMock.Object, _mapper);

        // Act
        trackService.DeleteTrack(1);

        // Assert
        _trackRepositoryMock.Verify(x => x.DeleteTrack(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void GetTracksWithSpecificAlbumIdForList_ShouldReturnListOftracks()
    {
        // Arrange
        var trackService = new TrackService(_trackRepositoryMock.Object, _mapper);
        var tracks = new List<Domain.Model.Track>
        {
            new()
            {
                Id = 1,
                Title = "test",
                Album = new Album { Id = 1 },
                AlbumId = 1,
                Length = 1
            },
            new()
            {
                Id = 2,
                Title = "test2",
                Album = new Album { Id = 1 },
                AlbumId = 1,
                Length = 1
            }
        };
        var queryableTracks = tracks.AsQueryable();
        _trackRepositoryMock.Setup(x => x.GetAllTracks()).Returns(queryableTracks);

        // Act
        var result = trackService.GetTracksWithSpecificAlbumIdForList(2, 1, "", 1, "ascending");

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Theory]
    [InlineData(2, 1, "test", 1, "ascending")]
    [InlineData(1, 1, "test", 2, "ascending")]
    [InlineData(1, 2, "test2", 1, "ascending")]
    [InlineData(0, 2, "test3", 1, "ascending")]
    public void GetTracksWithSpecificAlbumIdForList_ShouldReturnCorrectNumberOfTracks(int expected, int pageSize,
        string searchString, int albumId, string sortOrder)
    {
        // Arrange
        var trackService = new TrackService(_trackRepositoryMock.Object, _mapper);
        var tracks = new List<Domain.Model.Track>
        {
            new()
            {
                Id = 1,
                Title = "test",
                Album = new Album { Id = 1 },
                AlbumId = 1,
                Length = 1
            },
            new()
            {
                Id = 2,
                Title = "test2",
                Album = new Album { Id = 1 },
                AlbumId = 1,
                Length = 1
            },
            new()
            {
                Id = 2,
                Title = "test2",
                Album = new Album { Id = 2 },
                AlbumId = 2,
                Length = 1
            }
        };
        var queryableTracks = tracks.AsQueryable();
        _trackRepositoryMock.Setup(x => x.GetAllTracks()).Returns(queryableTracks);

        // Act
        var result = trackService.GetTracksWithSpecificAlbumIdForList(pageSize, 1, searchString, albumId, sortOrder);

        // Assert
        Assert.Equal(expected, result.Count);
    }

    [Fact]
    public void GetTrackForEdit_ShouldReturnTrack()
    {
        // Arrange
        var trackService = new TrackService(_trackRepositoryMock.Object, _mapper);
        var track = new Domain.Model.Track
        {
            Id = 1,
            Title = "test",
            Album = new Album { Id = 1 },
            AlbumId = 1,
            Length = 1
        };
        _trackRepositoryMock.Setup(x => x.GetTrackById(It.IsAny<int>())).Returns(track);

        // Act
        var result = trackService.GetTrackForEdit(1);

        // Assert
        Assert.Equal(track.Id, result.Id);
    }

    [Fact]
    public void UpdateTrack_ShouldReturnTrack()
    {
        // Arrange
        var trackService = new TrackService(_trackRepositoryMock.Object, _mapper);
        var track = new NewTrackVm
        {
            Id = 1,
            Title = "test"
        };
        var trackDomain = new Domain.Model.Track
        {
            Id = 1,
            Title = "test",
            Album = new Album { Id = 1 },
            AlbumId = 1,
            Length = 1
        };
        _trackRepositoryMock.Setup(x => x.GetTrackById(It.IsAny<int>())).Returns(trackDomain);

        // Act
        var result = trackService.UpdateTrack(track);

        // Assert
        Assert.Equal(track.Id, result.Id);
    }
}