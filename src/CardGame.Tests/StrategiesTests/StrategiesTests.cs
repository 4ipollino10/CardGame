using CardGame.Common.Domain;
using CardGame.Strategies.Models;
using CardGame.Strategies.Services;
using FluentAssertions;
using NUnit.Framework;

namespace CardGame.Tests.StrategiesTests;

public class StrategiesTests
{
    [TestCase(StrategyType.FirstCardStrategy)]
    [TestCase(StrategyType.MirrorStrategy)]
    public void GetStrategyWillWorkCorrectly(StrategyType strategyType)
    {
        // Arrange
        var fixture = new StrategiesTestsFixture();
        var sut = fixture.GetSut<StrategyProvider>();

        // Act
        var strategy = sut.GetStrategy(strategyType);

        // Assert
        strategy.GetStrategyName().Should().Be(strategyType.ToString());
    }

    [TestCaseSource(typeof(StrategiesTestCaseSources), nameof(StrategiesTestCaseSources.DecksParameters))]
    public void StrategyUsingWillWorkCorrectly(Card[] deck, StrategyType strategyType, CardType expectedCardType, int expectedIndex)
    {
        // Arrange
        var fixture = new StrategiesTestsFixture();
        var sut = fixture.GetSut<StrategyProvider>();
        var strategy = sut.GetStrategy(strategyType);

        // Act
        var result = strategy.PickCard(deck);

        // Assert
        result.Should().Be(expectedIndex);
        deck[expectedIndex].CardType.Should().Be(expectedCardType);
    }
}