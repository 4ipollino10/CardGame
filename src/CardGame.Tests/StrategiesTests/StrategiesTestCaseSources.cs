using CardGame.Common.Domain;
using CardGame.Strategies.Models;

namespace CardGame.Tests.StrategiesTests;

public static class StrategiesTestCaseSources
{
    public static readonly object[] DecksParameters =
    {
        new object[] { new Card[] { new (CardType.Black), new (CardType.Red) }, StrategyType.FirstCardStrategy, CardType.Black, 0 },
        new object[] { new Card[] { new (CardType.Red), new (CardType.Black) }, StrategyType.FirstCardStrategy, CardType.Red, 0 },
        
        new object[] { new Card[] { new (CardType.Red), new (CardType.Red) }, StrategyType.MirrorStrategy, CardType.Red, 0 },
        new object[] { new Card[] { new (CardType.Red), new (CardType.Black) }, StrategyType.MirrorStrategy, CardType.Red , 0 },
        new object[] { new Card[] { new (CardType.Black), new (CardType.Red) }, StrategyType.MirrorStrategy, CardType.Red , 1 },
        new object[] { new Card[] { new (CardType.Black), new (CardType.Black) }, StrategyType.MirrorStrategy, CardType.Black , 0 }
    };
}