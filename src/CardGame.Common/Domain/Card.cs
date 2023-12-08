namespace CardGame.Common.Domain;

/// <summary>
/// Контракт карты
/// </summary>
public sealed class Card
{
    /// <summary>
    /// Тип карты
    /// </summary>
    public CardType CardType { get; set; }

    /// <summary>
    /// init
    /// </summary>
    /// <param name="cardType"></param>
    public Card(CardType cardType)
    {
        CardType = cardType;
    }
}