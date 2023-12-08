namespace CardGame.ObserverRoom.Core.GameDomain.Entities;

public enum ActivitySessionStatus
{
    /// <summary>
    /// В процессе
    /// </summary>
    InProgress,
    
    /// <summary>
    /// Завершена
    /// </summary>
    Ended,
    
    /// <summary>
    /// Отложенная
    /// </summary>
    Delayed
}