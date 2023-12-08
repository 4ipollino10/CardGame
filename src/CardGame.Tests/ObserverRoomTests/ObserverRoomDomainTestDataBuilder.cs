using CardGame.Common.Contracts;
using CardGame.Common.Types;
using CardGame.ObserverRoom.Core.GameDomain.Entities;
using CardGame.Strategies.Models;
using JsonNet.PrivateSettersContractResolvers;
using Newtonsoft.Json;

namespace CardGame.Tests.ObserverRoomTests;

public static class ObserverRoomDomainTestDataBuilder
{
    private static T Construct<T>()
    {
        return JsonConvert.DeserializeObject<T>("{}", new JsonSerializerSettings
        {
            ContractResolver = new PrivateSetterContractResolver(),
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        })!;
    }
    
    public static ActivitySession GetActivitySession(int amountOfGames = 10)
    {
        var activitySession = Construct<ActivitySession>();
        var activitySessionId = Guid.NewGuid();
        
        activitySession.SetProperty(x => x.MuskStrategy, StrategyType.MirrorStrategy);
        activitySession.SetProperty(x => x.ZuckerbergStrategy, StrategyType.MirrorStrategy);
        activitySession.SetProperty(x => x.Id, activitySessionId);
        activitySession.SetProperty(x => x.Status, ActivitySessionStatus.InProgress);
        activitySession.SetProperty(x => x.AmountOfEndedGames, amountOfGames);

        var games = new List<Game>();
        for (var i = 0; i < amountOfGames; ++i)
        {
            var game = Construct<Game>();
            
            game.SetProperty(x => x.GameResult, i % 2 == 0 ? GameResultType.Loose : GameResultType.Win);
            game.SetProperty(x => x.Status, GameStatus.Ended);
            game.SetProperty(x => x.MuskStrategy, StrategyType.MirrorStrategy);
            game.SetProperty(x => x.ZuckerbergStrategy, StrategyType.MirrorStrategy);
            game.SetProperty(x => x.ActivitySessionId, activitySessionId);
            game.SetProperty(x => x.Id, Guid.NewGuid());
            
            games.Add(game);
        }
        
        activitySession.SetProperty(x => x.Games, games);
        
        return activitySession;
    }

}

