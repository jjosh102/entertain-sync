using System.Text.Json;
using EntertainSync.Core.Models;
using EntertainSync.Core.Models.External;

namespace EntertainSync.Core.Services;

public class MyAnimelistClient
{
    private readonly HttpClient _httpClient;

    public MyAnimelistClient(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<Result<MyAnimeList>> GetAsync()
    {
        //test
        var url  = "https://api.myanimelist.net/v2/anime/season/2022/fall?limit=1&fields=id,title,main_picture,alternative_titles,start_date,end_date,synopsis,mean,rank,popularity,num_list_users,num_scoring_users,nsfw,created_at,updated_at,media_type,status,genres,my_list_status,num_episodes,start_season,broadcast,source,average_episode_duration,rating,pictures,background,related_anime,related_manga,recommendations,studios,statistics";
        var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        if (await JsonSerializer.DeserializeAsync<MyAnimeList>(content) is {} data)
        {
            return data;
        }
        return Result.Failure<MyAnimeList>(Error.NullValue);
    }
  
}

