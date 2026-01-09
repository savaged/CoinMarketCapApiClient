using ConsoleTables;

namespace CoinMarketCapApiClient;

public class ConsoleView : IView
{
    public object? DataContext { get; set; }

    public void Show()
    {
        if (DataContext is IIndexViewModel ivm)
        {
            if (ivm.Index?.Count() > 0)
                ConsoleTable.From<Model>(ivm.Index)
                    .Configure(c => c.NumberAlignment = Alignment.Right)
                    .Write(Format.MarkDown);
            else
                Console.WriteLine(ivm.Status);
        }
    }

    public async Task LoadAsync()
    {
        if (DataContext is IIndexViewModel ivm)
            await ivm.LoadAsync();
    }

    public void Clear() => Console.Clear();

}
