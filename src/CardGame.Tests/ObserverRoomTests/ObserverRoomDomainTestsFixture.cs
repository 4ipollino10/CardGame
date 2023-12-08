using CardGame.Common.DependencyInjection;
using CardGame.ObserverRoom.Application;
using CardGame.ObserverRoom.Application.Game;
using CardGame.ObserverRoom.Application.Ports;
using CardGame.ObserverRoom.Core.GameDomain;
using CardGame.ObserverRoom.Core.GameDomain.Entities;
using CardGame.ObserverRoom.Core.Ports;
using CardGame.Tests.Bootstrap;
using CardGame.Tests.ObserverRoomTests.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace CardGame.Tests.ObserverRoomTests;

public class ObserverRoomDomainTestsFixture
{
    public GameManagementStorageMock GameManagementStorage { get; } = new();
    
    public T GetSut<T>() where T : class
    {
        return CompositionRoot.ServiceProviderWithOverride(services =>
            {
                services.AddSingleton<ApplicationExecutionContext>();
                services.AddSingleton<GameContext>();
                services.AddSingleton<ObserverRoomService>();
                services.AddSingleton<IGamesManagementStorage>(GameManagementStorage)
                    .As<IDatabaseMaintenance>();
            })
            .GetRequiredService<T>();
    }

    public ActivitySession AddActivitySession()
    {
        var activitySession = ObserverRoomDomainTestDataBuilder.GetActivitySession(8);
        GameManagementStorage.AddNewActivitySession(activitySession);
        return activitySession;
    }
}