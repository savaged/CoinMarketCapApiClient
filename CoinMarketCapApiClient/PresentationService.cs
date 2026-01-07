namespace CoinMarketCapApiClient;

public static class PresentationService
{
    public static string Show(Root? root, Watchlist watchlist)
    {
        if (root is null || root.data is null)
            return "No data available!";
        if (watchlist is null || watchlist.Count == 0)
            return "Empty watchlist!";
        var matches = root.data.Where(datum =>
            datum.symbol is not null
            && watchlist.ContainsKey(datum.symbol)
            && watchlist[datum.symbol] == datum.name);
        var sb = new System.Text.StringBuilder();
        foreach (var crypto in matches)
            sb.AppendLine(Line(crypto));
        return sb.ToString();
    }

    private static string Line(Datum d) =>
        $"{d.name} ({d.symbol}): ${d.quote.USD.price:F2} {d.quote.USD.percent_change_1h:F2}%";

}
