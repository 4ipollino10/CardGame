using System.Text;
using CardGame.Common;
using CardGame.Common.Contracts;
using CardGame.Common.Types;
using CardGame.ObserverRoom.Core.GameDomain.Entities;
using CardGame.ObserverRoom.Core.Ports;
using CardGame.Strategies.Models;
using Newtonsoft.Json;
using static System.Enum;

namespace CardGame.ObserverRoom.Core.GameDomain;

public class GameContext
{
    private readonly IGamesManagementStorage _gamesManagementStorage;

    /// <summary>
    /// init
    /// </summary>
    /// <param name="gamesManagementStorage"></param>
    public GameContext(IGamesManagementStorage gamesManagementStorage)
    {
        _gamesManagementStorage = gamesManagementStorage;
    }

    /// <summary>
    /// Создаст отложенную сессию активности
    /// </summary>
    /// <param name="model"></param>
    /// <param name="activitySessionId"></param>
    public async Task<ActivitySession> CreateDelayedActivitySession(GameConfigurationModel model, Guid activitySessionId)
    {
        return await CreateActivitySession(model, activitySessionId, ActivitySessionStatus.Delayed, GameStatus.Delayed);
    }

    /// <summary>
    /// Запустит сессию активности
    /// </summary>
    /// <param name="activitySession"></param>
    public async Task RunGames(ActivitySession activitySession)
    {
        await SendStrategies(activitySession.MuskStrategy, activitySession.ZuckerbergStrategy);
        
        foreach (var game in activitySession.Games)
        {
            await EmulateGame(game);
        }
    }

    /// <summary>
    /// Вернет идентификаторы всех сесий активности
    /// </summary>
    public async Task<List<Guid>> GetAllActivitySessionsIds()
    {
        var activitySessions = await _gamesManagementStorage.GetAllActivitySessions();

        return activitySessions.Select(x => x.Id).ToList();
    }

    /// <summary>
    /// Вернет сессию активности по id
    /// </summary>
    /// <param name="activitySessionId"></param>
    public async Task<ActivitySession?> GetActivitySessionById(Guid activitySessionId)
    {
        return await _gamesManagementStorage.GetActivitySessionById(activitySessionId);
    }

    /// <summary>
    /// Вернет игры, проведенные в сессии активности по id сессии активности
    /// </summary>
    /// <param name="activitySessionId"></param>
    public async Task<List<Game>?> GetGamesByActivitySessionId(Guid activitySessionId)
    {
        return await _gamesManagementStorage.GetGamesByActivitySessionId(activitySessionId);
    }

    public async Task SetGameResult(GameResult model)
    {
        var game = await _gamesManagementStorage.GetGameById(model.GameId);
        game.SetResult(model);
        await _gamesManagementStorage.UpdateGame(game);
        
        var activitySession = await _gamesManagementStorage.GetActivitySessionById(game.ActivitySessionId);
        activitySession!.EndGame();
        
        if (activitySession.AmountOfEndedGames == activitySession.Games.Count)
        {
            activitySession.EndActivity();
        }
        await _gamesManagementStorage.UpdateActivitySession(activitySession);
    }

    private async Task<ActivitySession> CreateActivitySession(
        GameConfigurationModel model
        , Guid activitySessionId
        , ActivitySessionStatus activitySessionStatus
        , GameStatus gameStatus)
    {
        var games = new List<Game>();
        TryParse<StrategyType>(model.MuskGameStrategy, out var muskStrategy);
        TryParse<StrategyType>(model.ZuckerbergGameStrategy, out var zuckerbergStrategy);

        for (var i = 0; i < model.AmountOfGames; ++i)
        {
            games.Add(new Game(muskStrategy, zuckerbergStrategy, gameStatus));
        }

        return await _gamesManagementStorage.AddNewActivitySession(
            new ActivitySession(
                games
                , activitySessionStatus
                , muskStrategy
                , zuckerbergStrategy
                , activitySessionId)
        );
    }
    
    /// <summary>
    /// Устанавливает стратегии игрокам
    /// </summary>
    /// <param name="muskStrategy"></param>
    /// <param name="zuckerbergStrategy"></param>
    private async Task SendStrategies(StrategyType muskStrategy, StrategyType zuckerbergStrategy)
    {
        using var client = new HttpClient();
        var muskEndpoint = new Uri(ApplicationConstants.MuskRoutesConstants.SetStrategyRoute);
        var zuckerbergEndpoint = new Uri(ApplicationConstants.ZuckerbergRoutesConstants.SetStrategyRoute);

        var muskRequest = JsonConvert.SerializeObject(
            new StrategyRequest()
            {
                StrategyType = muskStrategy
            }
        );

        var zuckerbergRequest = JsonConvert.SerializeObject(
            new StrategyRequest()
            {
                StrategyType = zuckerbergStrategy
            }
        );

        var muskPayload = new StringContent(muskRequest, Encoding.UTF8, "application/json");
        var zuckerbergPayload = new StringContent(zuckerbergRequest, Encoding.UTF8, "application/json");

        await client.PostAsync(muskEndpoint, muskPayload);
        await client.PostAsync(zuckerbergEndpoint, zuckerbergPayload);
    }

    /// <summary>
    /// Запускает одну игру
    /// </summary>
    /// <param name="game"></param>
    private async Task EmulateGame(Game game)
    {
        using var client = new HttpClient();
        var godsEndpoint = new Uri(ApplicationConstants.AncientGodsRoutesConstants.StartGameRoute);

        var godsRequest = JsonConvert.SerializeObject(
            new GameModel()
            {
                GameId = game.Id,
                ActivitySessionId = game.ActivitySessionId
            }
        );

        var godsPayload = new StringContent(godsRequest, Encoding.UTF8, "application/json");
        await client.PostAsync(godsEndpoint, godsPayload);
    }
}