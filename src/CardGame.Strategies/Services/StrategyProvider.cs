using CardGame.Strategies.Models;
using CardGame.Strategies.Strategies;

namespace CardGame.Strategies.Services;

public class StrategyProvider : IStrategyProvider
{
    private readonly Dictionary<StrategyType, IStrategy> _strategies = new ();
    
    public StrategyProvider()
    {
        _strategies.Add(StrategyType.FirstCardStrategy, new FirstCardStrategy());
        _strategies.Add(StrategyType.MirrorStrategy, new MirrorStrategy());
    }

    public IStrategy GetStrategy(StrategyType strategyType)
    {
        return _strategies[strategyType];
    }
}