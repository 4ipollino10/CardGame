using CardGame.AncientGods.Core.GameDomain.Entities;

namespace CardGame.AncientGods.Core.Adapters;

public interface IGameStorage
{
    Task AddPlayerChoiceMessage(PlayerChoice message);
    Task<PlayerChoice?> GetPlayerChoiceMessageByGameIdAndDescriptor(Guid gameId, string descriptor);
    Task<int> GetPlayerChoiceCardNumByGameIdAndDescriptor(Guid gameId, string descriptor);
    Task<Game> AddGame(Game game);
    Task<Game> GetGameById(Guid gameId);
}