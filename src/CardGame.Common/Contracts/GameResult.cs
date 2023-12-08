using JetBrains.Annotations;

namespace CardGame.Common.Contracts;

[PublicAPI]
public class GameResult
{
    /// <summary>
    /// Идентификатор игры
    /// </summary>
    public Guid GameId { get; set; }
    
    /// <summary>
    /// Результат игры
    /// </summary>
    public GameResultType GameResultType { get; set; }

    /// <summary>
    /// Игровая колода
    /// </summary>
    public string Deck { get; set; } = null!;
}