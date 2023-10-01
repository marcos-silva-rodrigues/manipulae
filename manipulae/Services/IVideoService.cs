using manipulae.Data.Models;

namespace manipulae.Services;

public interface IVideoService
{
    Video[] GetAllVideos();
    Video Insert();
    void Update();
    void Delete();
}