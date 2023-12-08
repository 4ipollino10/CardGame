using CardGame.Common.Contracts;
using CardGame.Common.Types;
using CardGame.Strategies.Models;
using JetBrains.Annotations;

namespace CardGame.ObserverRoom.Core.GameDomain.Entities;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class Game
{
    /// <summary>
    /// Конструктор для EF
    /// </summary>
    private Game()
    {
        
    }

    public Game(StrategyType zuckerbergStrategy, StrategyType muskStrategy, GameStatus gameStatus)
    {
        Status = gameStatus;
        ZuckerbergStrategy = zuckerbergStrategy;
        MuskStrategy = muskStrategy;
    }
    
    /// <summary>
    /// Идентификатор игры
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Идентификатор сессии активности
    /// </summary>
    public Guid ActivitySessionId { get; set; }

    /// <summary>
    /// Состояние игры
    /// </summary>
    public GameStatus Status { get; private set; }

    /// <summary>
    /// Стратегия игры Марка Цукерберга
    /// </summary>
    public StrategyType ZuckerbergStrategy { get; set; }

    /// <summary>
    /// Стратегия игры Илона Маска
    /// </summary>
    public StrategyType MuskStrategy { get; set; }

    /// <summary>
    /// Json строка с колодой игры
    /// </summary>
    public string? JsonDeck { get; set; }

    /// <summary>
    /// Итог игры
    /// </summary>
    public GameResultType? GameResult { get; set; }

    internal void SetResult(GameResult result)
    {
        GameResult = result.GameResultType;
        JsonDeck = result.Deck;
        Status = GameStatus.Ended;
    }
}