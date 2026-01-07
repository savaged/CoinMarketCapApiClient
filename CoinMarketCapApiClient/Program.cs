using CoinMarketCapApiClient;

var model = await CoinMarketCapApiService.LoadLatestAsync();

Console.WriteLine(model?.status?.total_count);
