using CoinMarketCapApiClient;

var watchlist = new Watchlist();
var model = await CoinMarketCapApiService.LoadLatestAsync();

Console.WriteLine(PresentationService.Show(model, watchlist));

