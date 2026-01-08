namespace CoinMarketCapApiClient;

public class ViewModel : IIndexViewModel
{
    public async Task LoadAsync()
    {
        var watchlist = new Watchlist();
        if (watchlist is null || watchlist.Count == 0)
            return; // TODO publish invalid state
        var root = await CoinMarketCapApiService.LoadLatestAsync();
        if (root is null || root.data is null)
            return; // TODO publish invalid state
        Index = ModelMappingService.Map(WatchlistFilteringService.Filter(root, watchlist));
    }

    public IEnumerable<Model> Index { get; private set; } = [];
}
