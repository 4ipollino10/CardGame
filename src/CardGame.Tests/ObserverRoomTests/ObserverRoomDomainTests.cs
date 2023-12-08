using CardGame.ObserverRoom.Application.Game;
using FluentAssertions;
using NUnit.Framework;

namespace CardGame.Tests.ObserverRoomTests;

public class ObserverRoomDomainTests
{
    [Test]
    public async Task ActivitySessionResultWillCountCorrectly()
    {
        // Arrange
        var expectedAmountWins = 4;
        var fixture = new ObserverRoomDomainTestsFixture();
        var activitySession = fixture.AddActivitySession();
        var sut = fixture.GetSut<ObserverRoomService>();
        
        // Act
        var result = await sut.GetActivitySessionResult(activitySession.Id);

        // Assert
        result.AmountOfWins.Should().Be(expectedAmountWins);
        result.Percentage.Should().Be("50%");
    }
}