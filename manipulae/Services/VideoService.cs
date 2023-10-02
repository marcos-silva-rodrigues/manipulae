using manipulae.Data;
using manipulae.Data.Dto;
using manipulae.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace manipulae.Services;

public class VideoService : IVideoService
{
    private readonly VideoDbContext _context;

    public VideoService(VideoDbContext context)
    {
        _context = context;
    }

    public Video? FindVideoById(string id)
    {
        return _context.Videos
            .Where(video => video.IsDeleted != true)
            .FirstOrDefault(entity => entity.Id == id);
    }

    public Video[] GetVideosAndFilter(string? q, DateTime? after)
    {
        var videos = _context.Videos
            .Where(video => video.IsDeleted != true)
            .Where(video => after != null
                ? video.CreatedAt >= after
                : true)
            .Where(video => q != null
                ? (
                    EF.Functions.Like(video.Autor, $"%{q}%") ||
                    EF.Functions.Like(video.Description, $"%{q}%") ||
                    EF.Functions.Like(video.Title, $"%{q}%")
                )
                : true)
            .ToArray();

        return videos;
    }

    public bool MarkDeleted(string id)
    {
        var exists = FindVideoById(id);
        if (exists == null)
        {
            return false;
        }

        exists.IsDeleted = true;
        _context.SaveChanges();
        return true;
    }

    public Video? Insert(CreateVideoDto dto)
    {
        var exists = FindVideoById(dto.Id);
        if (exists != null)
        {
            return null;
        }

        var video = CreateVideoDto.FromVideo(dto);

        _context.Videos.Add(video);
        _context.SaveChanges();

        return video;
    }

    public bool Update(string id, UpdateVideoDto dto)
    {
        var exists = FindVideoById(id);
        if (exists == null)
        {
            return false;
        }

        exists.Url = dto.Url;
        exists.Title = dto.Title;
        exists.Autor = dto.Autor;
        exists.Description = dto.Description;

        _context.SaveChanges();
        return true;
    }

}