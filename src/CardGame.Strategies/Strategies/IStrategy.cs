using CardGame.Common.Domain;

namespace CardGame.Strategies.Strategies;

public interface IStrategy
{
    string GetStrategyName();

    int PickCard(Card[] deck);
}