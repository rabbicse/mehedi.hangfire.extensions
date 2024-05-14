using Hangfire;
using Newtonsoft.Json;

namespace Mehedi.Hangfire.Extensions;

/// <summary>
/// Provides extension methods for configuring Hangfire to use MediatR with custom JSON serializer settings.
/// Source: https://gist.github.com/dcomartin/5e8438967cb866ed6995a5e4aea123c0#file-hangfireconfigurationextensions-cs
/// </summary>
public static class HangfireConfigurationExtensions
{
    /// <summary>
    /// Configures Hangfire to use MediatR with custom JSON serializer settings.
    /// </summary>
    /// <param name="configuration">The <see cref="IGlobalConfiguration"/> instance to configure.</param>
    public static void UseMediatR(this IGlobalConfiguration configuration)
    {
        var jsonSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };
        configuration.UseSerializerSettings(jsonSettings);
    }
}
