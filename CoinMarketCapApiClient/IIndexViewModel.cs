namespace CoinMarketCapApiClient;

public interface IIndexViewModel : IViewModel
{
    IEnumerable<Model> Index { get; }
}
