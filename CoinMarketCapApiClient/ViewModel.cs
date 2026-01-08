namespace CoinMarketCapApiClient;

public class ViewModel : IIndexViewModel
{
    private readonly ICoinMarketCapApiService _coinMarketCapApiService;

    public ViewModel(ICoinMarketCapApiService coinMarketCapApiService)
    {
        ArgumentNullException.ThrowIfNull(coinMarketCapApiService);
        _coinMarketCapApiService = coinMarketCapApiService;
    }

    public async Task LoadAsync()
    {
        Status = string.Empty;
        var watchlist = new Watchlist();
        if (watchlist is null || watchlist.Count == 0)
        {
            Status = "No watchlist!";
            return;
        }
        var root = await _coinMarketCapApiService.LoadLatestAsync();
        if (root is null || root.data is null)
        {
            Status = "No data returned from API!";
            return;
        }
        Index = ModelMappingService.Map(WatchlistFilteringService.Filter(root, watchlist));
        Status = "Loaded";
    }

    public IEnumerable<Model> Index { get; private set; } = [];

    public string Status { get; private set; } = "Not loaded";
}
