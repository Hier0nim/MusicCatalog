using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using MusicCatalog.Application.Interfaces;
using MusicCatalog.Application.Services;
using MusicCatalog.Application.ViewModels.Track;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MusicCatalog.Test.Track
{
    public class TrackServiceTests
    {
        private readonly TrackService _trackService;
        private readonly ITrackRepository _trackRepo;
        private readonly IMapper _mapper;
        public TrackServiceTests()
        {
            //Dependencies
            _mapper = A.Fake<IMapper>();
            _trackRepo = A.Fake<ITrackRepository>();
            //SUT
            _trackService = new TrackService(_trackRepo, _mapper);
        }

        [Fact]
        public void TrackService_AddTrack_ReturnsInt()
        {
            //Arrange
            NewTrackVm NewTrackVm = new NewTrackVm();
            Domain.Model.Track track = new Domain.Model.Track();
            A.CallTo(() => _trackRepo.AddTrack(track)).Returns(0);
            //Act
            var result = _trackService.AddTrack(NewTrackVm, 0);
            //Assert
            result.Should().Be(0);
        }

        [Fact]
        public void TrackService_GetTracksWithSpecificAlbumIdForList_ReturnsObject()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void TrackService_GetTrackForEdit_ReturnsObject()
        {
            //Arrange

            //Act

            //Assert

        }

        [Fact]
        public void TrackService_UpdateTrack_ReturnsObject()
        {
            //Arrange

            //Act

            //Assert

        }
    }
}
