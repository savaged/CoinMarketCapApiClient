namespace CoinMarketCapApiClient;

public static class PresentationService
{
    public static string Show(Root? root, Watchlist watchlist)
    {
        if (root is null || root.data is null)
            return "No data available!";
        if (watchlist?.Count == 0)
            return "Empty watchlist!";
        var matches = root.data.Where(datum =>
            watchlist.ContainsKey(datum.symbol)
            && watchlist[datum.symbol] == datum.name);
        var sb = new System.Text.StringBuilder();
        foreach (var crypto in matches)
            sb.AppendLine($"{crypto.name} ({crypto.symbol}): ${crypto.quote.USD.price:F2}");
        return sb.ToString();
    }
}
