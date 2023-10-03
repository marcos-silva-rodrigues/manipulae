using manipulae.Data;
using manipulae.Data.Dto;
using manipulae.Data.Models;
using manipulae.Services;
using manipulae_unit_test.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manipulae_unit_test
{
    public class VideoServiceTest
    {

        private readonly IVideoService _videoService;
        private readonly VideoDbContext _context;

        public static readonly object[][] QueryOptions =
        {
            new object[] { "Farmacia", new DateTime(2022, 2, 1), 1 },
            new object[] { "Produção", new DateTime(2022, 2, 1), 2},
            new object[] { "manipula", new DateTime(2022, 1, 1), 3},
            new object[] { "manipula", new DateTime(2022, 12, 1), 1},
            new object[] { "Fulano", new DateTime(2022, 1, 1), 2}
        };

        public VideoServiceTest()
        {
            _context = new VideoContextFactory().CreateDbContext();
            AddMockData();
            _videoService = new VideoService(_context);
        }

        private void AddMockData()
        {
            _context.Videos.Add(new Video()
            {
                Id = "XPTO1",
                Autor = "Fulano 1",
                CreatedAt = new DateTime(2022, 08, 21),
                Description = "O que São manipulados",
                IsDeleted = false,
                Title = "Produção de manipulados pt 1",
                Url = "xtpolink",
            });

            _context.Videos.Add(new Video()
            {
                Id = "XPTO2",
                Autor = "DR  Fulano",
                CreatedAt = new DateTime(2023, 02, 12),
                Description = "Tipo de manipulados",
                IsDeleted = false,
                Title = "Produção de manipulados pt 2",
                Url = "xtpolink",
            });

            _context.Videos.Add(new Video()
            {
                Id = "XPTO3",
                Autor = "Dra faz de conta",
                CreatedAt = new DateTime(2022, 11, 07),
                Description = "Como encontrar uma boa farmacia de manipulação",
                IsDeleted = false,
                Title = "Farmacia de manipulação",
                Url = "xtpolink",
            });

            _context.SaveChanges();
        }

        [Fact]
        public void ShouldReturnVideos()
        {
            var list = _videoService.GetVideosAndFilter(null, null);

            Assert.Equal(3, list.Length);
        }

        [Theory, MemberData(nameof(QueryOptions))]
        public void ShouldReturnVideosWithFilters(string q, DateTime afterDate, int expectedLength)
        {
            var list = _videoService.GetVideosAndFilter(q, afterDate);

            Assert.Equal(expectedLength, list.Length);
        }

        [Fact]
        public void ShouldFindVideoById()
        {
            var video = _videoService.FindVideoById("XPTO1");

            Assert.NotNull(video);
            Assert.Equal("Fulano 1", video.Autor);
            Assert.Equal("O que São manipulados", video.Description);
            Assert.Equal("Produção de manipulados pt 1", video.Title);
        }

        [Fact]
        public void ShouldNotGetVideoDeleted()
        {
            var videoDeleted = new Video()
            {
                Id = "XPTO4",
                Autor = "Dr Imaginario",
                CreatedAt = new DateTime(2020, 11, 07),
                Description = "Resolva seus problemas com manipulados",
                IsDeleted = true,
                Title = "Fique Grande usando Oxandrolona",
                Url = "xtpolink",
            };
            _context.Videos.Add(videoDeleted);
            _context.SaveChanges();

            var video = _videoService.FindVideoById("XPTO4");

            Assert.Null(video);

            _context.Videos.Remove(videoDeleted);
        }

        [Fact]
        public void ShouldReturnVideoCreated()
        {
            var videoDeleted = new CreateVideoDto()
            {
                Id = "XPTO4",
                Autor = "Dr Imaginario",
                CreatedAt = new DateTime(2020, 11, 07),
                Description = "Resolva seus problemas com manipulados",
                Title = "Não seja calvo",
                Url = "xtpolink",
            };

            var video = _videoService.Insert(videoDeleted);

            Assert.NotNull(video);
        }

        [Fact]
        public void ShouldReturnNullWhenVideoIdAlreadyExists()
        {
            var videoDeleted = new CreateVideoDto()
            {
                Id = "XPTO3",
                Autor = "Dr Imaginario",
                CreatedAt = new DateTime(2020, 11, 07),
                Description = "Resolva seus problemas com manipulados",
                Title = "Não seja calvo",
                Url = "xtpolink",
            };

            var video = _videoService.Insert(videoDeleted);

            Assert.Null(video);
        }

        [Fact]
        public void ShouldReturnTrueWhenVideoUpdated()
        {
            var id = "XPTO3";
            var videoUpdated = new UpdateVideoDto()
            {
                Autor = "Dr Imaginario",
                Description = "Resolva seus problemas com manipulados",
                Title = "Não seja calvo",
                Url = "xtpolink",
            };

            var isSuccess = _videoService.Update(id, videoUpdated);
            Assert.True(isSuccess);
        }

        [Theory]
        [InlineData("XPTO1", true)]
        [InlineData("XPT12", false)]
        public void ShouldUpdateVideo(string id, bool expected)
        {
            var videoUpdated = new UpdateVideoDto()
            {
                Autor = "Dr Imaginario",
                Description = "Resolva seus problemas com manipulados",
                Title = "Não seja calvo",
                Url = "xtpolink",
            };

            var isSuccess = _videoService.Update(id, videoUpdated);
            Assert.Equal(expected, isSuccess);
        }

        [Theory]
        [InlineData("XPTO1", true)]
        [InlineData("XPT12", false)]
        public void ShouldMarkedVideoDeleted(string id, bool expected)
        {
            var isSuccess = _videoService.MarkDeleted(id);
            Assert.Equal(expected, isSuccess);
        }

    }
}
