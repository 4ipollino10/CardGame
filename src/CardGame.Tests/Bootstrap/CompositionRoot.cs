using Microsoft.Extensions.DependencyInjection;

namespace CardGame.Tests.Bootstrap;
using Microsoft.Extensions.Configuration;

internal static class CompositionRoot
{
    private static IServiceCollection ServiceCollection { get; }
    private static IServiceProvider? _serviceProvider;
    public static IServiceProvider ServiceProvider => _serviceProvider ??= ServiceCollection.BuildServiceProvider();

    public static IConfigurationRoot Configuration { get; set; }

    public static IServiceProvider ServiceProviderWithOverride(Action<IServiceCollection> action)
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        foreach (var descriptor in ServiceCollection)
        {
            serviceCollection.Add(descriptor);
        }

        action(serviceCollection);

        var ips = serviceCollection.BuildServiceProvider();
        return ips;
    }
    
    static CompositionRoot()
    {
        Configuration = new ConfigurationBuilder()
            .Build();


        ServiceCollection = new ServiceCollection();
    }
}