using CoinMarketCapApiClient;

var config = ConfigBuilder.Build();

var coinMarketCapApiService = new CoinMarketCapApiService(
        config["CoinMarketCap:Environment"] ?? "sandbox",
        config["CoinMarketCap:ApiKey"] ?? "b54bcf4d-1bca-4e8e-9a24-22ff2c3d462c");

var consoleView = new ConsoleView()
{
    DataContext = new MainViewModel(coinMarketCapApiService)
};

using var cts = new CancellationTokenSource();
// Start a background task to listen for the 'Q' key
var keyTask = Task.Run(() =>
{
    while (true)
    {
        if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q)
        {
            cts.Cancel(); // Signal the loop to stop immediately
            break;
        }
    }
});
try
{
    while (!cts.Token.IsCancellationRequested)
    {
        consoleView.Clear();
        await consoleView.LoadAsync();
        consoleView.Show();
        // Pass the token to Task.Delay.
        // If cts.Cancel() is called, this delay terminates immediately.
        await Task.Delay(int.TryParse(config["CoinMarketCap:RefreshDelay"], out int i) ? i : 20000, cts.Token);
    }
}
catch (OperationCanceledException)
{
    consoleView.Clear();
}
