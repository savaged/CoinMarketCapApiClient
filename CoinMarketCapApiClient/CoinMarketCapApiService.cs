using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CoinMarketCapApiClient;

public static class CoinMarketCapApiService
{
    private const string API_ENV = "pro"; // Change to "sandbox" for sandbox environment
    private static readonly HttpClient _httpClient = new();

    public static async Task<Root?> LoadLatestAsync()
    {
        var latest = await DownloadLatestAsync();
        var root = JsonSerializer.Deserialize<Root>(latest);
        return root;
    }

    private static async Task<string> DownloadLatestAsync()
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, BuildQueryString(BuildQueryParams()));
        request.Headers.Add("X-CMC_PRO_API_KEY", "3ba7c384-939c-4d9c-83ce-1c6dfb206db2");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        using var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    private static Dictionary<string, string?> BuildQueryParams() =>
        new Dictionary<string, string?>
        {
            ["start"] = "1",
            ["limit"] = "5000",
            ["convert"] = "USD"
        };

    private static string BuildQueryString(Dictionary<string, string?> queryParams) =>
        QueryHelpers.AddQueryString(
            $"https://{API_ENV}-api.coinmarketcap.com/v1/cryptocurrency/listings/latest",
            queryParams);
}
