using CardGame.Common.Domain;

namespace CardGame.AncientGods.Application.Game.Deck;

/// <summary>
/// Сервис, работающий с колодой
/// </summary>
public class DeckManipulatorService
{
    private static Random rng = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);
    
    private const int DeckCapacity = 36;

    /// <summary>
    /// Создает новую колоду
    /// </summary>
    public Card[] GetNewDeck()
    {
        var deck = new Card[DeckCapacity];

        for (var i = 0; i < DeckCapacity / 2; ++i)
        {
            deck[i] = new Card(CardType.Black);
        }
        
        for (var i = DeckCapacity / 2; i < DeckCapacity; ++i)
        {
            deck[i] = new Card(CardType.Red);
        }

        return deck;
    }

    /// <summary>
    /// Тасует колоду
    /// </summary>
    /// <param name="deck"></param>
    /// <returns></returns>
    public Card[] ShuffleDeck(Card[] deck)
    {
        for (var i = deck.Length - 1; i >= 0; i--)
        {
            var j = rng.Next(i + 1);
            // обменять значения data[j] и data[i]
            (deck[j], deck[i]) = (deck[i], deck[j]);
        }

        return deck;
    }

    /// <summary>
    /// Разделяет колоду на две одинаковые стопки
    /// </summary>
    /// <param name="deck"></param>
    /// <param name="firstHalf"></param>
    /// <param name="secondHalf"></param>
    public void SeparateDeckOnHalf(Card[] deck, out Card[] firstHalf, out Card[] secondHalf)
    {
        firstHalf = deck.SubArray(0, DeckCapacity / 2);
        secondHalf = deck.SubArray(DeckCapacity / 2, DeckCapacity / 2);
    }
}

public static class Extensions
{
    public static T[] SubArray<T>(this T[] array, int offset, int length)
    {
        return array.Skip(offset)
            .Take(length)
            .ToArray();
    }
}