using manipulae.Controllers;
using manipulae.Data.Dto;
using manipulae.Data.Models;
using manipulae.Services;
using manipulae_unit_test.Mock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace manipulae_unit_test
{
    public class VideoControllerTest
    {
        

        [Fact]
        public void ShouldReturn200WithVideoArray()
        {
            var serviceMock = new Mock<IVideoService>();
            serviceMock.Setup(s =>
                s.GetVideosAndFilter(It.IsAny<string?>(), It.IsAny<DateTime?>())
                ).Returns(new Video[] { VideosMock.CreateVideoEntity() });

            var controller = new VideoController(serviceMock.Object);
            var result = controller.FindAll(null, null);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void ShouldReturn404WhenNotFoundId()
        {
            var serviceMock = new Mock<IVideoService>();
            serviceMock.Setup(s =>
                s.FindVideoById(It.IsAny<string>())
                ).Returns((Video) null);

            var controller = new VideoController(serviceMock.Object);
            var result = controller.Find("xpt0");

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void ShouldReturn200WhenFoundVideo()
        {
            var serviceMock = new Mock<IVideoService>();
            serviceMock.Setup(s =>
                s.FindVideoById(It.IsAny<string>())
                ).Returns(VideosMock.CreateVideoEntity());

            var controller = new VideoController(serviceMock.Object);
            var result = controller.Find("xpto");

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void ShouldReturn409WhenVideoIdAlreadyExists()
        {
            var serviceMock = new Mock<IVideoService>();
            serviceMock.Setup(s =>
                s.Insert(It.IsAny<CreateVideoDto>())
                ).Returns((Video) null);

            var controller = new VideoController(serviceMock.Object);
            var result = controller.Create(VideosMock.CreateVideoDto());

            Assert.IsType<ConflictResult>(result.Result);
        }

        [Fact]
        public void ShouldReturn201WhenCreatedVideos()
        {
            var serviceMock = new Mock<IVideoService>();
            serviceMock.Setup(s =>
                s.Insert(It.IsAny<CreateVideoDto>())
                ).Returns(VideosMock.CreateVideoEntity());

            var controller = new VideoController(serviceMock.Object);
            var result = controller.Create(VideosMock.CreateVideoDto());

            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public void ShouldReturn204WhenUpdatedVideo()
        {
            var serviceMock = new Mock<IVideoService>();
            serviceMock.Setup(s =>
                s.Update(It.IsAny<string>(), It.IsAny<UpdateVideoDto>())
                ).Returns(true);

            var controller = new VideoController(serviceMock.Object);
            var result = controller.UpdateVideoById("xpto", VideosMock.UpdateVideoDto());

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void ShouldReturn404WhenNotFoundVideoByUpdate()
        {
            var serviceMock = new Mock<IVideoService>();
            serviceMock.Setup(s =>
                s.Update(It.IsAny<string>(), It.IsAny<UpdateVideoDto>())
                ).Returns(false);

            var controller = new VideoController(serviceMock.Object);
            var result = controller.UpdateVideoById("xpto", VideosMock.UpdateVideoDto());

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void ShouldReturn204WhenDeleteVideo()
        {
            var serviceMock = new Mock<IVideoService>();
            serviceMock.Setup(s =>
                s.MarkDeleted(It.IsAny<string>())
                ).Returns(true);

            var controller = new VideoController(serviceMock.Object);
            var result = controller.DeleteById("xpto");

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void ShouldReturn404WhenNotFoundVideoByDelete()
        {
            var serviceMock = new Mock<IVideoService>();
            serviceMock.Setup(s =>
                s.MarkDeleted(It.IsAny<string>())
                ).Returns(false);

            var controller = new VideoController(serviceMock.Object);
            var result = controller.DeleteById("xpto");

            Assert.IsType<NotFoundResult>(result);
        }


    }
}