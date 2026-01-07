namespace CoinMarketCapApiClient;

public static class PresentationService
{
    public static void Show(Root? root, Watchlist watchlist)
    {
        if (root is null || root.data is null)
        {
            Console.WriteLine("No data available.");
            return;
        }
        var matches = root.data.Join(watchlist, 
                                 datum => datum.name,
                                 watched => watched,
                                 (datum, watched) => datum);
        foreach (var crypto in matches)
            Console.WriteLine($"{crypto.name} ({crypto.symbol}): ${crypto.quote.USD.price:F2}");
    }
}
