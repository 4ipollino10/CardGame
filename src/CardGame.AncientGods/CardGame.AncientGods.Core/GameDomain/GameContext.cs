using CardGame.AncientGods.Core.Adapters;
using CardGame.AncientGods.Core.GameDomain.Entities;
using CardGame.Common;
using CardGame.Common.Domain;
using CardGame.Common.Messaging.Contracts;
using Newtonsoft.Json;

namespace CardGame.AncientGods.Core.GameDomain;

public class GameContext
{
    private readonly IGameStorage _gameStorage;

    /// <summary>
    /// init
    /// </summary>
    /// <param name="gameStorage"></param>
    public GameContext(IGameStorage gameStorage)
    {
        _gameStorage = gameStorage;
    }

    public async Task<PlayerChoice?> GetPlayerChoiceMessageByGameIdAndDescriptor(Guid gameId, string descriptor)
    {
        return await _gameStorage.GetPlayerChoiceMessageByGameIdAndDescriptor(gameId, descriptor);
    }

    public async Task AddPlayerChoiceMessage(PlayerChoiceModel model)
    {
        await _gameStorage.AddPlayerChoiceMessage(new PlayerChoice(model));
    }

    public async Task<AnswerPair> GetAnswerPairBy(Guid gameId)
    {
        return new AnswerPair()
        {
            MuskCardNumChoice = await _gameStorage.GetPlayerChoiceCardNumByGameIdAndDescriptor(gameId, ApplicationConstants.MuskDescriptor),
            ZuckerbergCardNumChoice = await _gameStorage.GetPlayerChoiceCardNumByGameIdAndDescriptor(gameId, ApplicationConstants.ZuckerbergDescriptor),
        };
    }

    public async Task<Game> AddGame(Guid gameId, Card[] deck)
    {
        var deckJson = JsonConvert.SerializeObject(deck);
        return await _gameStorage.AddGame(new Game(gameId, deckJson));
    }

    public async Task<Game> GetGameById(Guid gameId)
    {
        return await _gameStorage.GetGameById(gameId);
    }
}