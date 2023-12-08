using CardGame.AncientGods.Application.Ports;
using CardGame.AncientGods.Core.Adapters;
using CardGame.AncientGods.Core.GameDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardGame.AncientGods.Infrastructure.GameDomain.EntityFramework.Adapters;

public class GameStorage : IGameStorage, IDatabaseMaintenance
{
    private readonly GameDbContext _dbContext;

    public GameStorage(GameDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddPlayerChoiceMessage(PlayerChoice message)
    {
        await _dbContext.PlayerChoice.AddAsync(message);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Game> AddGame(Game game)
    {
        var result = await _dbContext.Game.AddAsync(game);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Game> GetGameById(Guid gameId)
    {
        return (await _dbContext.Game.FirstOrDefaultAsync(x => x.Id == gameId))!;
    }

    public async Task<PlayerChoice?> GetPlayerChoiceMessageByGameIdAndDescriptor(Guid gameId, string descriptor)
    {
        var playerChoice =
            await _dbContext.PlayerChoice
                .FirstOrDefaultAsync(
                    x => x.GameId == gameId 
                    && x.Descriptor == descriptor);

        return playerChoice;
    }

    public async Task<int> GetPlayerChoiceCardNumByGameIdAndDescriptor(Guid gameId, string descriptor)
    {
        var result = await _dbContext.PlayerChoice.FirstOrDefaultAsync(x => x.GameId == gameId && x.Descriptor == descriptor);
        return result!.PlayerChoiceCardNum;
    }

    public IDatabaseMaintenance AsNoTrackingWithIdentityResolution()
    {
        _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
        return this;
    }

    public async Task BeginTransaction()
    {
        await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransaction()
    {
        await _dbContext.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransaction()
    {
        await _dbContext.Database.RollbackTransactionAsync();
    }
}