namespace CoinMarketCapApiClient;

public class ViewModel : IIndexViewModel
{
    public async Task LoadAsync()
    {
        Status = string.Empty;
        var watchlist = new Watchlist();
        if (watchlist is null || watchlist.Count == 0)
        {
            Status = "No watchlist!";
            return;
        }
        var root = await CoinMarketCapApiService.LoadLatestAsync();
        if (root is null || root.data is null)
        {
            Status = "No data returned from API!";
            return;
        }
        Index = ModelMappingService.Map(WatchlistFilteringService.Filter(root, watchlist));
        Status = "Loaded";
    }

    public IEnumerable<Model> Index { get; private set; } = [];

    public string Status { get; private set; } = string.Empty;
}
