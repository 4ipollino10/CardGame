using CardGame.Common.Domain;
using JetBrains.Annotations;

namespace CardGame.Common.Messaging.Contracts;

[PublicAPI]
public sealed record SendDeckModel
{
    /// <summary>
    /// Id сообщения
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Идентификатор игры
    /// </summary>
    public Guid GameId { get; set; }

    /// <summary>
    /// Стопка карт для игрока
    /// </summary>
    public Card[] Stack { get; set; } = null!;
}