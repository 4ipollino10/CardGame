using CardGame.Common.Domain;
using CardGame.MuskRoom.Application.Game;
using CardGame.Strategies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.MuskRoom.Controllers;

/// <summary>
/// Контроллер команты Илона Маска
/// </summary>
[ApiController, Route("/musk/api")]
public sealed class MuskRoomController
{
    private readonly MuskRoomService _muskRoomService;

    /// <summary>
    /// init
    /// </summary>
    /// <param name="muskRoomService"></param>
    public MuskRoomController(MuskRoomService muskRoomService)
    {
        _muskRoomService = muskRoomService;
    }
    
    /// <summary>
    /// Устанавливает статегию игры
    /// </summary>
    [HttpPost, Route("set-strategy")]
    public void SetStrategy(StrategyRequest request)
    {
        _muskRoomService.SetStrategy(request.StrategyType);
    }

    /// <summary>
    /// Возвращает цвет карты по номеру
    /// </summary>
    /// <param name="cardNumber"></param>
    [HttpGet, Route("get-answer/{answerPair.ZuckerbergCardNumChoice}")]
    public CardType GetOpponentCardColor([FromRoute] int cardNumber)
    {
        return _muskRoomService.GetOpponentCardColor(cardNumber);
    }
}