using CardGame.Common.Domain;
using CardGame.Strategies.Models;
using CardGame.Strategies.Services;
using CardGame.Strategies.Strategies;

namespace CardGame.MuskRoom.Application.Game;

/// <summary>
/// Сервис команты Илона Маска
/// </summary>
public sealed class MuskRoomService
{
    private readonly IStrategyProvider _strategyProvider;
    private IStrategy Strategy { get; set; } = null!;

    private Card[] _stack = Array.Empty<Card>();
    
    /// <summary>
    /// init
    /// </summary>
    /// <param name="strategyProvider"></param>
    public MuskRoomService(IStrategyProvider strategyProvider)
    {
        _strategyProvider = strategyProvider;
    }

    public void SetStrategy(StrategyType strategy)
    {
        Strategy = _strategyProvider.GetStrategy(strategy);
    }

    public int UseStrategy(Card[] stack)
    {
        _stack = stack;
        return Strategy.PickCard(stack);
    }

    public CardType GetOpponentCardColor(int cardNumber)
    {
        return _stack[cardNumber].CardType;
    }
}