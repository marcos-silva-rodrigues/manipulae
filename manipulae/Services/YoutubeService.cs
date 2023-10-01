using System.Collections;
using System.Text.Json;
using manipulae.Data.Dto;

namespace manipulae.Services;

public class YoutubeSeederService : IVideosSeederService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public YoutubeSeederService(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }

    public YoutubeApiResponse? GetVideos()
    {
        var apiKey = _configuration["ApiKey"];
        if (apiKey == null) return null;
        var url = BuilderUrl(apiKey);

        var response = _httpClient.GetStringAsync(url);
        var json = JsonSerializer.Deserialize<YoutubeApiResponse>(response.Result);

        if (json == null)
        {
            Console.WriteLine("Sem dados");
            return null;
        };
        return json;
    }

    private string BuilderUrl(string key)
    {
        var baseURL = "https://www.googleapis.com/youtube/v3/search?";
        var queryParams = "part=snippet&q=manipulação de medicamentos&regionCode=BR&maxResults=50&publishedAfter=2022-01-01T00:00:00Z&type=video";
        var request = baseURL + queryParams + "&key=" + key;
        return request;
    }
}