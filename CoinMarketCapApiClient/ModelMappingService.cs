namespace CoinMarketCapApiClient;

public static class ModelMappingService
{
    public static IEnumerable<Model> Map(IEnumerable<Datum> data)
    {
        if (data is null)
            return [];
        List<Model> list = [];
        foreach (var d in data)
            list.Add(new Model(d));
        return list;
    }
}
