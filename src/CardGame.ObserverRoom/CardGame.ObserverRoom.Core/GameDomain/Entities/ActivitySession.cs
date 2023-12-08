using CardGame.Strategies.Models;
using JetBrains.Annotations;

namespace CardGame.ObserverRoom.Core.GameDomain.Entities;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class ActivitySession
{
    /// <summary>
    /// Конструктор для EF
    /// </summary>
    private ActivitySession()
    {
        
    }

    public ActivitySession(
        List<Game> games
        , ActivitySessionStatus status
        , StrategyType muskStrategy
        , StrategyType zuckerbergStrategy
        , Guid id)
    {
        Id = id;
        Games = games;
        Status = status;
        MuskStrategy = muskStrategy;
        ZuckerbergStrategy = zuckerbergStrategy;
    }
    
    /// <summary>
    /// Идентификатор сессии активности
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Количество завершенных игр в активности
    /// </summary>
    public int AmountOfEndedGames { get; private set; }

    /// <summary>
    /// Состояние активности
    /// </summary>
    public ActivitySessionStatus Status { get; private set; }

    /// <summary>
    /// Стратегия Илона Маска
    /// </summary>
    public StrategyType MuskStrategy { get; private set; }
    
    /// <summary>
    /// Стратегия Марка Цукерберга
    /// </summary>
    public StrategyType ZuckerbergStrategy { get; private set; }

    /// <summary>
    /// Игры проводимые в рамках сессии активности
    /// </summary>
    public List<Game> Games { get; private set; } = null!;

    internal void EndGame()
    {
        AmountOfEndedGames++;
    }

    internal void EndActivity()
    {
        Status = ActivitySessionStatus.Ended;
    }
}