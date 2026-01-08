namespace CoinMarketCapApiClient;

public interface IView : ILoadable
{
    object? DataContext { get; set; }

    void Show();

    void Clear();
}
