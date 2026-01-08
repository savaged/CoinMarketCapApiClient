using CoinMarketCapApiClient;

var view = new View()
{
    DataContext = new ViewModel()
};
await view.LoadAsync();
view.Show();

