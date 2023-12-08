using Microsoft.Extensions.DependencyInjection;

namespace CardGame.Common.DependencyInjection;

/// <summary>
/// Полезные расширения для DI
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection As<T>(this IServiceCollection services)
    {
        return services.As(typeof(T));
    }
    public static IServiceCollection As<T>(this IServiceCollection services, T? type) where T : Type
    {
        var previousRegistration = services.LastOrDefault();
        if (previousRegistration == null)
        {
            throw new InvalidOperationException("Previous registration was not found");
        }

        ServiceDescriptor serviceDescriptor;
        if (previousRegistration.ImplementationInstance != null)
        {
            serviceDescriptor = new ServiceDescriptor(type!, previousRegistration.ImplementationInstance);
        }
        else if (previousRegistration.ImplementationFactory != null)
        {
            serviceDescriptor = new ServiceDescriptor(type!, previousRegistration.ImplementationFactory, previousRegistration.Lifetime);
        }
        else if (previousRegistration.ImplementationType != null)
        {
            serviceDescriptor = new ServiceDescriptor(type!, previousRegistration.ImplementationType, previousRegistration.Lifetime);
        }
        else
        {
            throw new NotImplementedException("Overloaded constructor was not found for previousRegistration");
        }
        services.Add(serviceDescriptor);
        return services;
    }
}