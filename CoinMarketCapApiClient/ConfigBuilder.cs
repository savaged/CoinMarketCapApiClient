using Microsoft.Extensions.Configuration;

namespace CoinMarketCapApiClient;

public static class ConfigBuilder
{
    /// <summary>
    /// Builds and returns an application configuration root that combines settings from the 'appsettings.json' file and
    /// environment variables.
    /// The appsettings.json file required at runtime needs to be added with the following content...
    /// <code>
    /// {
    ///   "CoinMarketCap": {
    ///     "Environment": "pro",
    ///     "ApiKey": "REPLACE_WITH_YOUR_API_KEY"
    ///   }
    /// }
    /// </code>
    /// </summary>
    /// <remarks>
    /// The returned configuration root automatically reloads settings if 'appsettings.json' changes
    /// at runtime. The base path for configuration files is set to the current working directory. Environment variables
    /// override values from 'appsettings.json' when keys overlap.
    /// </remarks>
    /// <returns>
    /// An <see cref="IConfigurationRoot"/> instance containing the merged configuration settings. If 'appsettings.json'
    /// is missing, only environment variables are included.
    /// </returns>
    public static IConfigurationRoot Build()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        var config = builder.Build();
        return config;
    }
}
