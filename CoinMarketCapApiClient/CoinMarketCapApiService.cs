using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CoinMarketCapApiClient;

public class CoinMarketCapApiService : ICoinMarketCapApiService
{
    private readonly string _apiEnv;
    private readonly string _apiKey;
    private readonly HttpClient _httpClient = new();

    public CoinMarketCapApiService(string apiEnv, string apiKey)
    {
        if (string.IsNullOrWhiteSpace(apiEnv))
            throw new ArgumentNullException(nameof(apiEnv));
        _apiEnv = apiEnv;
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new ArgumentNullException(nameof(apiKey));
        _apiKey = apiKey;
    }

    public async Task<Root?> LoadLatestAsync() =>
        JsonSerializer.Deserialize<Root>(await DownloadLatestAsync());

    private async Task<string> DownloadLatestAsync()
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, BuildQueryString(BuildQueryParams()));
        request.Headers.Add("X-CMC_PRO_API_KEY", _apiKey);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        using var response = await _httpClient.SendAsync(request);
        using var _ = response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    private static Dictionary<string, string?> BuildQueryParams() => new()
    {
        ["start"] = "1",
        ["limit"] = "5000",
        ["convert"] = "USD"
    };

    private string BuildQueryString(Dictionary<string, string?> queryParams) =>
        QueryHelpers.AddQueryString(
            $"https://{_apiEnv}-api.coinmarketcap.com/v1/cryptocurrency/listings/latest",
            queryParams);
}
