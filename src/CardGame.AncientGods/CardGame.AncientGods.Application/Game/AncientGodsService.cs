using CardGame.AncientGods.Application.Game.Deck;
using CardGame.AncientGods.Application.Messaging;
using CardGame.Common.Contracts;

namespace CardGame.AncientGods.Application.Game;

/// <summary>
/// Сервис богов, проводящих игру
/// </summary>
public class AncientGodsService
{
    private readonly SendDeckPublisher _sendDeckPublisher;
    private readonly DeckManipulatorService _deckManipulatorService;
    
    public AncientGodsService(DeckManipulatorService deckManipulatorService, SendDeckPublisher sendDeckPublisher)
    {
        _deckManipulatorService = deckManipulatorService;
        _sendDeckPublisher = sendDeckPublisher;
    }

    /// <summary>
    /// Запуск одной игр
    /// </summary>
    public async Task PlayGame(GameModel model)
    {
        var deck = _deckManipulatorService.GetNewDeck();
        deck = _deckManipulatorService.ShuffleDeck(deck);
        
        await _sendDeckPublisher.SendDecks(model.GameId, deck);
    }
}