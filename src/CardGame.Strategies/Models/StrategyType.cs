namespace CardGame.Strategies.Models;

/// <summary>
/// Типы стратегий
/// </summary>
public enum StrategyType
{
    /// <summary>
    /// Выбор первой карты
    /// </summary>
    FirstCardStrategy,
    
    /// <summary>
    /// Выбор первой красной карты
    /// </summary>
    MirrorStrategy
}