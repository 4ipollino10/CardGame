using CardGame.Common.Domain;
using CardGame.Strategies.Models;
using CardGame.ZuckerbergRoom.Application.Game;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.ZuckerbergRoom.API.Controllers;

/// <summary>
/// Контроллер команты Илона Маска
/// </summary>
[ApiController, Route("zuckerberg/api")]
public sealed class ZuckerbergRoomController
{
    private readonly ZuckerbergRoomService _zuckerbergRoomService;

    /// <summary>
    /// init
    /// </summary>
    /// <param name="zuckerbergRoomService"></param>
    public ZuckerbergRoomController(ZuckerbergRoomService zuckerbergRoomService)
    {
        _zuckerbergRoomService = zuckerbergRoomService;
    }
    
    /// <summary>
    /// Устанавливает статегию игры
    /// </summary>
    [HttpPost, Route("set-strategy")]
    public void SetStrategy(StrategyRequest request)
    {
        _zuckerbergRoomService.SetStrategy(request.StrategyType);
    }
    
    /// <summary>
    /// Возвращает цвет карты по номеру
    /// </summary>
    /// <param name="cardNumber"></param>
    [HttpGet, Route("get-answer/{answerPair.ZuckerbergCardNumChoice}")]
    public CardType GetOpponentCardColor([FromRoute] int cardNumber)
    {
        return _zuckerbergRoomService.GetOpponentCardColor(cardNumber);
    }
}