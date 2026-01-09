namespace CoinMarketCapApiClient;

public struct Model
{
    public Model(Datum d)
    {
        if (d is null)
            throw new NullReferenceException(nameof(Datum));
        if (d.quote is null)
            throw new NullReferenceException(nameof(Quote));
        if (d.quote.USD is null)
            throw new NullReferenceException(nameof(USD));
        Name = d.name ?? string.Empty;
        Symbol = d.symbol ?? string.Empty;
        USD = Math.Round(d.quote.USD.price, 2);
        Volume = Math.Round(d.quote.USD.volume_24h, 2);
        Volume_change_24h = Math.Round(d.quote.USD.volume_change_24h, 2);
        Percent_change_1h = Math.Round(d.quote.USD.percent_change_1h, 2);
        Percent_change_24h = Math.Round(d.quote.USD.percent_change_24h, 2);
        Percent_change_7d = Math.Round(d.quote.USD.percent_change_7d, 2);
        Percent_change_30d = Math.Round(d.quote.USD.percent_change_30d, 2);
        Percent_change_60d = Math.Round(d.quote.USD.percent_change_60d, 2);
        Percent_change_90d = Math.Round(d.quote.USD.percent_change_90d, 2);
    }

    public string Name { get; private set; }
    public string Symbol { get; private set; }
    public double USD { get; private set; }
    public double Volume { get; private set; }
    public double Volume_change_24h { get; private set; }
    public double Percent_change_1h { get; private set; }
    public double Percent_change_24h { get; private set; }
    public double Percent_change_7d { get; private set; }
    public double Percent_change_30d { get; private set; }
    public double Percent_change_60d { get; private set; }
    public double Percent_change_90d { get; private set; }
}
