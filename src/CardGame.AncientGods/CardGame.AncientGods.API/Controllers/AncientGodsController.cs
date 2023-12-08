using CardGame.AncientGods.Application.Game;
using CardGame.Common.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.AncientGodsAPI.Controllers;

/// <summary>
/// Контроллер богов 
/// </summary>
[ApiController, Route("/ancient-gods/api")]
public class AncientGodsController
{
    private readonly AncientGodsService _ancientGodsService;
    
    /// <summary>
    /// init
    /// </summary>
    /// <param name="ancientGodsService"></param>
    public AncientGodsController(AncientGodsService ancientGodsService)
    {
        _ancientGodsService = ancientGodsService;
    }

    /// <summary>
    /// Запускает игру
    /// </summary>
    /// <param name="model"></param>
    [HttpPost, Route("start-game")]
    public async Task StartGame(GameModel model)
    {
        await _ancientGodsService.PlayGame(model);
    }
}