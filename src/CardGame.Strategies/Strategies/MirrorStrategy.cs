using CardGame.Common.Domain;

namespace CardGame.Strategies.Strategies;

public class MirrorStrategy : IStrategy
{
    public string GetStrategyName()
    {
        return nameof(MirrorStrategy);
    }

    public int PickCard(Card[] deck)
    {
        for(var i = 0; i < deck.Length; ++i)
        {
            if (deck[i].CardType != CardType.Red) continue;
            return i;
        }

        return 0;
    }
}