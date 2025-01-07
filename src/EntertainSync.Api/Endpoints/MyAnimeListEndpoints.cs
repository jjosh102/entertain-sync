

using EntertainSync.Api.Extensions;
using EntertainSync.Core.Models;
using EntertainSync.Core.Models.External;
using EntertainSync.Core.Services;


namespace EntertainSync.Api.Endpoints;

public class MyAnimeListEndpoints : IEndpoint
{
  private const string tag = "MyAnimelist";

  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapGet("mal/get", async (MyAnimelistClient myAnimelistClient) =>
        {
          Result<MyAnimeList> result = await myAnimelistClient.GetAsync();

          return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        })
        .WithTags(tag);
  }
}