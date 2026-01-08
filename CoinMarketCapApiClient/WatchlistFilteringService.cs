namespace CoinMarketCapApiClient;

public static class WatchlistFilteringService
{
    public static IEnumerable<Datum> Filter(Root root, Watchlist watchlist) =>
        root.data.Where(datum =>
            datum.symbol is not null
            && watchlist.ContainsKey(datum.symbol)
            && watchlist[datum.symbol] == datum.name);

}
