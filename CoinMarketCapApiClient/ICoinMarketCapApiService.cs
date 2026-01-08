
namespace CoinMarketCapApiClient
{
    public interface ICoinMarketCapApiService
    {
        Task<Root?> LoadLatestAsync();
    }
}