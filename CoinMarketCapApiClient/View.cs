namespace CoinMarketCapApiClient;

public class View
{
    public object? DataContext { get; set; }

    public void Show()
    {
        if (DataContext is IIndexViewModel ivm)
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

    private static string Line(Model c) =>
        $"{c.Name} ({c.Symbol}): ${c.Price:F2} {c.Percent_change_1h:F2}%";

}
