using CardGame.Common.Contracts;
using CardGame.ObserverRoom.Application.Game;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.ObserverRoom.API.Controllers;

[ApiController, Route("/card-game/api/observer-room")]
public sealed class ObserverRoomController
{
    private readonly ObserverRoomService _observerRoomService;

    /// <summary>
    /// init
    /// </summary>
    /// <param name="observerRoomService"></param>
    public ObserverRoomController(ObserverRoomService observerRoomService)
    {
        _observerRoomService = observerRoomService;
    }
    
    /// <summary>
    /// Проведет n игр и вернет результат в процентах побед
    /// </summary>
    [HttpPost, Route("emulate-games")]
    public async Task<Guid> EmulateGames(GameConfigurationModel model)
    {
        var activitySessionId = Guid.NewGuid();
        await _observerRoomService.EmulateGames(model, activitySessionId);
        return activitySessionId;
    }

    /// <summary>
    /// Создаст отложенную сессию активности
    /// </summary>
    /// <param name="model"></param>
    [HttpPost, Route("set-delayed-activity-session")]
    public async Task<Guid> SetDelayedActivitySession(GameConfigurationModel model)
    {
        var activitySessionId = Guid.NewGuid();
        await _observerRoomService.CreateDelayedActivitySession(model, activitySessionId);
        return activitySessionId;
    }

    /// <summary>
    /// Запустит отложенную сессию активности
    /// </summary>
    /// <param name="activitySessionId"></param>
    [HttpPost, Route("run-delayed-activity-session/{activitySessionId}")]
    public async Task<string> RunDelayedActivitySession([FromRoute] Guid activitySessionId)
    {
        return await _observerRoomService.RunDelayedActivitySession(activitySessionId);
    }
    
    /// <summary>
    /// Вернет массив идентификторов всех существующих сессий активности
    /// </summary>
    [HttpGet, Route("get-activity-sessions")]
    public async Task<List<Guid>> GetAllActivitySessions()
    {
        return await _observerRoomService.GetAllActivitySessions();
    }

    /// <summary>
    /// Вернет результат сессии активности
    /// </summary>
    /// <param name="activitySessionGuid"></param>
    [HttpGet, Route("get-activity-session-result/{activitySessionGuid:guid}")]
    public async Task<ActivitySessionResultState> GetActivitySessionResult([FromRoute] Guid activitySessionGuid)
    {
        return await _observerRoomService.GetActivitySessionResult(activitySessionGuid);
    }

    [HttpPost, Route("set-game-result")]
    public async Task SetGameResult(GameResult model)
    {
        await _observerRoomService.SetGameResult(model);
    }
}