using manipulae.Data.Dto;
using manipulae.Data.Models;

namespace manipulae.Services;

public interface IVideoService
{
    Video? FindVideoById(string id);
    Video[] GetAllVideos();
    Video? Insert(CreateVideoDto dto);
    bool Update(string id, UpdateVideoDto dto);
    bool MarkDeleted(string id);
}