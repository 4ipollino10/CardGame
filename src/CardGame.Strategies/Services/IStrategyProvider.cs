using CardGame.Strategies.Models;
using CardGame.Strategies.Strategies;

namespace CardGame.Strategies.Services;

public interface IStrategyProvider
{
    IStrategy GetStrategy(StrategyType strategyType);
}