namespace CoinMarketCapApiClient;

public static class PresentationService
{
    public static string Show(Root? root, Watchlist watchlist)
    {
        if (root is null || root.data is null)
            return "No data available!";
        if (watchlist is null || watchlist.Count == 0)
            return "Empty watchlist!";
        return Convert(ModelMappingService.Map(Filter(root, watchlist)));
    }

    private static IEnumerable<Datum> Filter(Root root, Watchlist watchlist) =>
        root.data.Where(datum =>
            datum.symbol is not null
            && watchlist.ContainsKey(datum.symbol)
            && watchlist[datum.symbol] == datum.name);

    private static string Convert(IEnumerable<Model> list)
    {
        if (list is null)
            return string.Empty;
        var sb = new System.Text.StringBuilder();
        foreach (var crypto in list)
            sb.AppendLine(Line(crypto));
        return sb.ToString();
    }

    private static string Line(Model c) =>
        $"{c.Name} ({c.Symbol}): ${c.Price:F2} {c.Percent_change_1h:F2}%";

}
