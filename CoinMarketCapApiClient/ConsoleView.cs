using ConsoleTables;

namespace CoinMarketCapApiClient;

public class ConsoleView : IView
{
    private string _canvas = string.Empty;
    public object? DataContext { get; set; }

    public void Show()
    {
        Paint();
        Console.WriteLine(_canvas);
    }

    public async Task LoadAsync()
    {
        if (DataContext is IIndexViewModel ivm)
            await ivm.LoadAsync();
    }

    public void Clear() => Console.Clear();

    private void Paint()
    {
        _canvas = string.Empty;
        if (DataContext is IIndexViewModel ivm)
        {
            if (ivm.Index?.Count() > 0)
                _canvas = ConsoleTable.From<Model>(ivm.Index)
                    .Configure(c => c.NumberAlignment = Alignment.Right)
                    .ToMarkDownString();
            else
                _canvas = ivm.Status;
        }
    }

}
