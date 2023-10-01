using System.Text.Json;
using System.Text.Json.Serialization;

namespace manipulae.Data.Dto;

public class YoutubeIdDto
{
    [JsonPropertyName("kind")]
    public string Kind { get; set; }

    [JsonPropertyName("videoId")]
    public string VideoId { get; set; }
};

public class SnippetDto
{

    [JsonPropertyName("publishedAt")]
    public DateTime PublishedAt { get; set; }

    [JsonPropertyName("channelId")]
    public string ChannelId { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("thumbnails")]
    public Dictionary<string, ThumbnailDto> Thumbnails { get; set; }

    [JsonPropertyName("channelTitle")]
    public string ChannelTitle { get; set; }

    [JsonPropertyName("liveBroadcastContent")]
    public string LiveBroadcastContent { get; set; }

    [JsonPropertyName("publishTime")]
    public DateTime PublishTime { get; set; }
}

public class ThumbnailDto
{

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }
}

public class VideoYoutubeDto
{


    [JsonPropertyName("kind")]
    public string Kind { get; set; }

    [JsonPropertyName("etag")]
    public string Etag { get; set; }

    [JsonPropertyName("id")]
    public YoutubeIdDto Id { get; set; }

    [JsonPropertyName("snippet")]
    public SnippetDto Snippet { get; set; }

}

public class PageInfo
{
    [JsonPropertyName("totalResults")]
    public int TotalResults { get; set; }

    [JsonPropertyName("resultsPerPage")]
    public int ResultsPerPage { get; set; }
}

public class YoutubeApiResponse
{
    [JsonPropertyName("kind")]
    public string Kind { get; set; }

    [JsonPropertyName("etag")]
    public string Etag { get; set; }

    [JsonPropertyName("nextPageToken")]
    public string? NextPageToken { get; set; }

    [JsonPropertyName("prevPageToken")]
    public string? PrevPageToken { get; set; }

    [JsonPropertyName("regionCode")]
    public string RegionCode { get; set; }

    [JsonPropertyName("items")]
    public VideoYoutubeDto[] Items { get; set; }

}
