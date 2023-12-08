using CardGame.ObserverRoom.Core.GameDomain.Entities;

namespace CardGame.ObserverRoom.Core.Ports;

public interface IGamesManagementStorage
{
    /// <summary>
    /// Получение сессии активности по id
    /// </summary>
    /// <param name="activitySessionId"></param>
    Task<ActivitySession?> GetActivitySessionById(Guid activitySessionId);

    /// <summary>
    /// Получение всех сессий активности
    /// </summary>
    Task<List<ActivitySession>> GetAllActivitySessions();

    /// <summary>
    /// Получение всех игр по id сессии активности
    /// </summary>
    /// <param name="activitySessionId"></param>
    Task<List<Game>?> GetGamesByActivitySessionId(Guid activitySessionId);

    /// <summary>
    /// Добавит новую сессию активности
    /// </summary>
    /// <param name="activitySession"></param>
    Task<ActivitySession> AddNewActivitySession(ActivitySession activitySession);

    /// <summary>
    /// Получение игры по id
    /// </summary>
    Task<Game> GetGameById(Guid gameId);

    /// <summary>
    /// Обновляет состояние игры
    /// </summary>
    /// <param name="game"></param>
    Task<Game> UpdateGame(Game game);

    /// <summary>
    /// Обновляет состояние сесси активности
    /// </summary>
    /// <param name="session"></param>
    Task<ActivitySession> UpdateActivitySession(ActivitySession session);
}