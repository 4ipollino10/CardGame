using JetBrains.Annotations;

namespace CardGame.Common.Messaging.Contracts;

[PublicAPI]
public sealed record PlayerChoiceModel
{
    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Идентификатор игры
    /// </summary>
    public Guid GameId { get; set; }
    
    /// <summary>
    /// Номер карты
    /// </summary>
    public int CardNumber { get; set; }

    /// <summary>
    /// Кем отправлено сообщение
    /// </summary>
    public string Descriptor { get; set; } = null!;
}