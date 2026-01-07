namespace CoinMarketCapApiClient;

public struct Crypto
{
    public Crypto(Datum d)
    {
        if (d is null)
            throw new NullReferenceException(nameof(Datum));
        if (d.quote is null)
            throw new NullReferenceException(nameof(Quote));
        if (d.quote.USD is null)
            throw new NullReferenceException(nameof(USD));
        Name = d.name ?? string.Empty;
        Symbol = d.symbol ?? string.Empty;
        Price = d.quote.USD.price;
        Percent_change_1h = d.quote.USD.percent_change_1h;
        Percent_change_24h = d.quote.USD.percent_change_24h;
        Percent_change_7d = d.quote.USD.percent_change_7d;
        Percent_change_30d = d.quote.USD.percent_change_30d;
        Percent_change_60d = d.quote.USD.percent_change_60d;
        Percent_change_90d = d.quote.USD.percent_change_90d;
        LastUpdated = d.quote.USD.last_updated;
    }

    public string Name { get; private set; }
    public string Symbol { get; private set; }
    public double Price { get; private set; }
    public double Percent_change_1h { get; private set; }
    public double Percent_change_24h { get; private set; }
    public double Percent_change_7d { get; private set; }
    public double Percent_change_30d { get; private set; }
    public double Percent_change_60d { get; private set; }
    public double Percent_change_90d { get; private set; }
    public DateTime LastUpdated { get; private set; }
}
