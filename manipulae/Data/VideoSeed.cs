using manipulae.Data.Dto;
using manipulae.Data.Models;
using manipulae.Services;

namespace manipulae.Data;

public class VideoSeeder
{
    private readonly VideoDbContext _context;
    private readonly IVideosSeederService _service;

    public VideoSeeder(VideoDbContext context, IVideosSeederService service)
    {
        this._context = context;
        this._service = service;
    }

    public void Execute()
    {
        var rowsCount = _context.Videos.Count();
        if (rowsCount != 0)
        {
            Console.WriteLine("Não executa seed");
            return;
        }
        var response = _service.GetVideos();
        if (response == null)
        {
            Console.WriteLine("Não há items");
        }


        foreach (var item in response.Items)
        {
            var video = new Video();
            video.Id = item.Id.VideoId;
            video.Autor = item.Snippet.ChannelTitle;
            video.Title = item.Snippet.Title;
            video.Description = item.Snippet.Description;
            video.CreatedAt = item.Snippet.PublishedAt;
            video.Url = "https://www.youtube.com/watch?v=" + item.Id.VideoId;
            _context.Add(video);
        }

        _context.SaveChanges();


    }
}