using CardGame.Common.Domain;

namespace CardGame.Strategies.Strategies;

public class FirstCardStrategy : IStrategy
{
    public string GetStrategyName()
    {
        return nameof(FirstCardStrategy);
    }

    public int PickCard(Card[] deck)
    {
        return 0;
    }
}