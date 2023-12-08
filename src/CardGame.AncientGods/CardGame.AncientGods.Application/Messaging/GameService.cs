using System.Text;
using CardGame.AncientGods.Core;
using CardGame.AncientGods.Core.GameDomain;
using CardGame.Common;
using CardGame.Common.Contracts;
using CardGame.Common.Domain;
using CardGame.Common.Messaging.Contracts;
using Newtonsoft.Json;

namespace CardGame.AncientGods.Application.Messaging;

public class GameService
{
    private readonly ApplicationExecutionContext _applicationContext;
    private readonly GameContext _gameContext;

    public GameService(ApplicationExecutionContext applicationContext, GameContext gameContext)
    {
        _applicationContext = applicationContext;
        _gameContext = gameContext;
    }

    public async Task HandleMessage(PlayerChoiceModel model)
    {
        await _applicationContext.RunCommand(async () =>
        {
            await _gameContext.AddPlayerChoiceMessage(model);

            var playerChoiceMessage = await _gameContext.GetPlayerChoiceMessageByGameIdAndDescriptor(
                model.GameId
                , model.Descriptor == ApplicationConstants.MuskDescriptor 
                    ? ApplicationConstants.ZuckerbergDescriptor
                    : ApplicationConstants.MuskDescriptor);
            
            if (playerChoiceMessage is null)
            {
                return;
            }

            var answerPair = await _gameContext.GetAnswerPairBy(model.GameId);
            await SetGameResult(answerPair, model.GameId);
        });
    }

    public async Task AddGame(Guid gameId, Card[] deck)
    {
        await _applicationContext.RunCommand(async () => { await _gameContext.AddGame(gameId, deck); });
    }
    
    private async Task SetGameResult(AnswerPair answerPair, Guid gameId)
    {
        using var client = new HttpClient();
        var muskEndpoint = new Uri(ApplicationConstants.MuskRoutesConstants.GetChoiceRoute + $"{answerPair.ZuckerbergCardNumChoice}");
        var zuckerbergEndpoint = new Uri(ApplicationConstants.ZuckerbergRoutesConstants.GetChoiceRoute + $"{answerPair.MuskCardNumChoice}");

        var muskAnswer = await client.GetAsync(muskEndpoint);
        var zuckerbergAnswer =  await client.GetAsync(zuckerbergEndpoint);

        var zuckChoice = Enum.Parse<CardType>(await muskAnswer.Content.ReadAsStringAsync());
        var muskChoice = Enum.Parse<CardType>(await zuckerbergAnswer.Content.ReadAsStringAsync());

        var gameResult = zuckChoice == muskChoice ? GameResultType.Win : GameResultType.Loose;
        var game = await _applicationContext.RunQuery(async () => await _gameContext.GetGameById(gameId));
        
        await SendGameResult(new GameResult()
        {
            GameResultType = gameResult,
            GameId = gameId,
            Deck = game.Deck
        }, client);
    }

    private async Task SendGameResult(GameResult state, HttpClient client)
    {
        var observerEndpoint = new Uri(ApplicationConstants.ObserverRoutesConstants.SetGameResultRote);
        var observerRequest = JsonConvert.SerializeObject(state);
        var observerPayload = new StringContent(observerRequest, Encoding.UTF8, "application/json");
        await client.PostAsync(observerEndpoint, observerPayload);
    }
}