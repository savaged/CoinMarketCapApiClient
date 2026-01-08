namespace CoinMarketCapApiClient;

public static class ModelMappingService
{
    public static IEnumerable<Crypto> Map(IEnumerable<Datum> data)
    {
        if (data is null)
            return [];
        List<Crypto> list = [];
        foreach (var d in data)
            list.Add(new Crypto(d));
        return list;
    }
}
