using manipulae.Data;
using manipulae.Data.Models;

namespace manipulae.Services;

public class VideoService : IVideoService
{
    private readonly VideoDbContext _context;

    public VideoService(VideoDbContext context)
    {
        _context = context;
    }
    public Video[] GetAllVideos()
    {
        return _context.Videos.Where(video => video.IsDeleted != true).ToArray();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public Video Insert()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

}