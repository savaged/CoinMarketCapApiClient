namespace CoinMarketCapApiClient;

public class View : IView
{
    public object? DataContext { get; set; }

    public void Show()
    {
        if (DataContext is IIndexViewModel ivm && ivm.Index?.Count() > 0)
            Console.WriteLine(Convert(ivm.Index));
    }

    public async Task LoadAsync()
    {
        if (DataContext is IIndexViewModel ivm)
            await ivm.LoadAsync();
    }

    private static string Convert(IEnumerable<Model> list)
    {
        if (list is null)
            return string.Empty;
        var sb = new System.Text.StringBuilder();
        foreach (var crypto in list)
            sb.AppendLine(Line(crypto));
        return sb.ToString();
    }

    private static string Line(Model m) =>
        $"{m.Name} ({m.Symbol}): ${m.Price:F2} {m.Percent_change_1h:F2}% @{m.LastUpdated}";

}
