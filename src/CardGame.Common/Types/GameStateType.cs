namespace CardGame.Common.Types;

/// <summary>
/// Модель состояний игр
/// </summary>
public enum GameStatus
{
    /// <summary>
    /// Игра в процессе
    /// </summary>
    InProgress,
    
    /// <summary>
    /// Игра завершена
    /// </summary>
    Ended,
    
    /// <summary>
    /// Игра отложена
    /// </summary>
    Delayed
}