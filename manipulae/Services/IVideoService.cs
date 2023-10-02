using manipulae.Data.Dto;
using manipulae.Data.Models;

namespace manipulae.Services;

public interface IVideoService
{
    Video? FindVideoById(string id);
    Video[] GetVideosAndFilter(string? q, DateTime? after);
    Video? Insert(CreateVideoDto dto);
    bool Update(string id, UpdateVideoDto dto);
    bool MarkDeleted(string id);
}