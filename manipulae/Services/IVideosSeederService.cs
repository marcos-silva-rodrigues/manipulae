using manipulae.Data.Dto;

namespace manipulae.Services;

public interface IVideosSeederService
{
    YoutubeApiResponse? GetVideos();
}