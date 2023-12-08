using CardGame.Common.Contracts;
using CardGame.Common.Types;
using CardGame.ObserverRoom.Core.GameDomain;
using CardGame.ObserverRoom.Core.GameDomain.Entities;

namespace CardGame.ObserverRoom.Application.Game;

public sealed class ObserverRoomService
{
    private readonly GameContext _gameContext;

    private readonly ApplicationExecutionContext _applicationContext;

    /// <summary>
    /// init
    /// </summary>
    /// <param name="gameContext"></param>
    /// <param name="applicationContext"></param>
    public ObserverRoomService(GameContext gameContext, ApplicationExecutionContext applicationContext)
    {
        _gameContext = gameContext;
        _applicationContext = applicationContext;
    }

    /// <summary>
    /// Проводит n игр с фиксацией результатов
    /// </summary>
    /// <param name="model"></param>
    /// <param name="activitySessionGuid"></param>
    public async Task EmulateGames(GameConfigurationModel model, Guid activitySessionGuid)
    {
        var activitySession = await _applicationContext.RunQuery(async () => 
            await _gameContext.CreateDelayedActivitySession(model, activitySessionGuid));
        
        await _gameContext.RunGames(activitySession);
    }

    public async Task CreateDelayedActivitySession(GameConfigurationModel model, Guid activitySessionGuid)
    {
        await _applicationContext.RunCommand(async () =>
        {
            await _gameContext.CreateDelayedActivitySession(model, activitySessionGuid);
        });
    }

    public async Task<string> RunDelayedActivitySession(Guid activitySessionId)
    {
        var message = await _applicationContext.RunQuery(async () =>
        {
            var returnMessage = string.Empty;
            var activitySession = await _gameContext.GetActivitySessionById(activitySessionId);
            
            if (activitySession is null)
            {
                returnMessage = "нет такой сесси активности";
                return returnMessage;
            }

            switch (activitySession.Status)
            {
                case ActivitySessionStatus.Ended:
                    returnMessage = "Сессия активности уже завершена";
                    return returnMessage;
                case ActivitySessionStatus.InProgress:
                    returnMessage = "Сессия активности уже запущена";
                    return returnMessage;
                case ActivitySessionStatus.Delayed:
                    returnMessage = "Сессия активности запущена";
                    break;
            }

            await _gameContext.RunGames(activitySession);

            return returnMessage;
        });
        
        return message;
    }

    /// <summary>
    /// Возвращает массив идентификаторов всех существующих сессий активности
    /// </summary>
    public async Task<List<Guid>> GetAllActivitySessions()
    {
        return await _applicationContext.RunQuery(async () => 
            await _gameContext.GetAllActivitySessionsIds()
        );
    }

    /// <summary>
    /// Возвращает результат сесси активности
    /// </summary>
    public async Task<ActivitySessionResultState> GetActivitySessionResult(Guid activitySessionId)
    {
        var activitySession = await _applicationContext.RunQuery(async () => 
            await _gameContext.GetActivitySessionById(activitySessionId)
        );

        if (activitySession is null)
        {
            throw new Exception();
            //тут должна быть нормальная ошибка, в идеале чтобы она еще через фильтр прошла, чтобы код нормальный выдать
        }
        
        var wins = 0.0;
        foreach (var game in activitySession.Games)
        {
            if (game.Status is not GameStatus.Ended)
            {
                continue;
            }
            
            if (game.GameResult is GameResultType.Win)
            {
                wins++;
            }
        }

        var message = activitySession.Status switch
        {
            ActivitySessionStatus.InProgress => "Сессия активности еще в процессе",
            ActivitySessionStatus.Ended => "Сессия активности завершена",
            _ => string.Empty
        };

        return new ActivitySessionResultState()
        {
            ActivitySessionGuid = activitySessionId,
            Message = message,
            Status = activitySession.Status.ToString(),
            AmountOfGames = activitySession.Games.Count,
            AmountOfWins = (int)wins,
            MuskStrategy = activitySession.MuskStrategy.ToString(),
            ZuckerbergStrategy = activitySession.ZuckerbergStrategy.ToString(),
            Percentage = wins / activitySession.Games.Count * 100 + "%"
        };
    }

    public async Task SetGameResult(GameResult model)
    {
        await _applicationContext.RunCommand(async () =>
        {
            await _gameContext.SetGameResult(model);
        });
    }
}