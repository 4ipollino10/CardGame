using CardGame.AncientGods.Application.Game.Deck;
using CardGame.Common;
using CardGame.Common.Domain;
using CardGame.Common.Messaging.Contracts;
using MassTransit;

namespace CardGame.AncientGods.Application.Messaging;

public sealed class SendDeckPublisher
{
    private readonly IBus _bus;
    private readonly GameService _gameService;
    private readonly DeckManipulatorService _deckManipulatorService;

    /// <summary>
    /// init
    /// </summary>
    /// <param name="bus"></param>
    /// <param name="gameService"></param>
    /// <param name="deckManipulatorService"></param>
    public SendDeckPublisher(IBus bus, GameService gameService, DeckManipulatorService deckManipulatorService)
    {
        _bus = bus;
        _gameService = gameService;
        _deckManipulatorService = deckManipulatorService;
    }

    public async Task SendDecks(Guid gameId, Card[] deck)
    {
        var muskEndpoint = await _bus.GetSendEndpoint(new Uri(ApplicationConstants.MuskRoutesConstants.MuskQueueRoute));
        var zuckerbergEndpoint = await _bus.GetSendEndpoint(new Uri(ApplicationConstants.ZuckerbergRoutesConstants.ZuckerbergQueueRoute));
        _deckManipulatorService.SeparateDeckOnHalf(deck, out var muskStack, out var zuckerbergStack);

        await _gameService.AddGame(gameId, deck);
        
        var muskMessage = new SendDeckModel()
        {
            Id = Guid.NewGuid(),
            GameId = gameId,
            Stack = muskStack,
        };
        
        var zuckerbergMessage = new SendDeckModel()
        {
            Id = Guid.NewGuid(),
            GameId = gameId,
            Stack = zuckerbergStack,
        };
        
        await muskEndpoint.Send(muskMessage);
        await zuckerbergEndpoint.Send(zuckerbergMessage);
    }
}