using CoinMarketCapApiClient;

var config = ConfigBuilder.Build();

var coinMarketCapApiService = new CoinMarketCapApiService(
    config["CoinMarketCap:Environment"] ?? "sandbox",
    config["CoinMarketCap:ApiKey"] ?? "b54bcf4d-1bca-4e8e-9a24-22ff2c3d462c");

var view = new ConsoleView()
{
    DataContext = new MainViewModel(coinMarketCapApiService)
};

// TODO add timed loop for clear, load and show
await view.LoadAsync();
view.Show();

