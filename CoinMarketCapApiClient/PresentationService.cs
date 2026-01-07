namespace CoinMarketCapApiClient;

public static class PresentationService
{
    public static string Show(Root? root, Watchlist watchlist)
    {
        if (root is null || root.data is null)
            return "No data available.";
        var matches = root.data.Join(watchlist,
            datum => datum.symbol,
            watched => watched.Key,
            (datum, watched) => datum);
        var sb = new System.Text.StringBuilder();
        foreach (var crypto in matches)
            sb.AppendLine($"{crypto.name} ({crypto.symbol}): ${crypto.quote.USD.price:F2}");
        return sb.ToString();
    }
}
