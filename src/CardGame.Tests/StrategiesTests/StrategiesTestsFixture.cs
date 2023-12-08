using CardGame.Tests.Bootstrap;
using Microsoft.Extensions.DependencyInjection;

namespace CardGame.Tests.StrategiesTests;

public class StrategiesTestsFixture
{
    public T GetSut<T>() where T : class
    {
        return CompositionRoot.ServiceProviderWithOverride(services =>
            {
                services.AddSingleton<T>();
            })
            .GetRequiredService<T>();
    }
}