using JetBrains.Annotations;

namespace CardGame.Common.Contracts;

/// <summary>
/// Контракт игры
/// </summary>
[PublicAPI]
public class GameModel
{
    /// <summary>
    /// Идентификатор сесии активности
    /// </summary>
    public Guid ActivitySessionId { get; set; }
    
    /// <summary>
    /// Идентификатор игры
    /// </summary>
    public Guid GameId { get; set; }
}