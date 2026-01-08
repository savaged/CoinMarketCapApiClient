namespace CoinMarketCapApiClient;

public class Watchlist : Dictionary<string, string>
{
    // TODO load this from file
    public Watchlist()
    {
        Add("BTC", "Bitcoin");
        Add("ETH", "Ethereum");
        Add("XRP", "XRP");
        Add("XMR", "Monero");
        Add("XAUt", "Tether Gold");
        Add("KAS", "Kaspa");
        Add("FIL", "Filecoin");
        Add("BAT", "Basic Attention Token");
        Add("QRL", "Quantum Resistant Ledger");
        Add("ZANO", "Zano");
    }
}
