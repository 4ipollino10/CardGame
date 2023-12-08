using CardGame.Common.Messaging.Contracts;
using MassTransit;

namespace CardGame.AncientGods.Application.Messaging;

public class PlayerChoiceConsumer : IConsumer<PlayerChoiceModel>
{
    private readonly GameService _gameService;

    public PlayerChoiceConsumer(GameService gameService)
    {
        _gameService = gameService;
    }

    public async Task Consume(ConsumeContext<PlayerChoiceModel> context)
    {
        await _gameService.HandleMessage(context.Message);
    }
}