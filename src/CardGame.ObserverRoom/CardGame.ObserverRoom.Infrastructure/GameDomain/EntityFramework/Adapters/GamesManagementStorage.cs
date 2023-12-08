using CardGame.ObserverRoom.Application.Ports;
using CardGame.ObserverRoom.Core.GameDomain.Entities;
using CardGame.ObserverRoom.Core.Ports;
using Microsoft.EntityFrameworkCore;

namespace CardGame.ObserverRoom.Infrastructure.GameDomain.EntityFramework.Adapters;

public class GamesManagementStorage : IGamesManagementStorage, IDatabaseMaintenance
{
    private readonly GameDbContext _dbContext;

    public GamesManagementStorage(GameDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ActivitySession?> GetActivitySessionById(Guid activitySessionId)
    {
        return (await _dbContext.ActivitySessions.Include(x => x.Games).FirstOrDefaultAsync(x => x.Id == activitySessionId))!;
    }

    public async Task<List<ActivitySession>> GetAllActivitySessions()
    {
        return await _dbContext.ActivitySessions.ToListAsync();
    }

    public async Task<List<Game>?> GetGamesByActivitySessionId(Guid activitySessionId)
    {
        var activitySession = await _dbContext.ActivitySessions.FirstOrDefaultAsync(x => x.Id == activitySessionId);

        return activitySession?.Games;
    }

    public async Task<ActivitySession> AddNewActivitySession(ActivitySession activitySession)
    {
        var createdActivitySession = await _dbContext.ActivitySessions.AddAsync(activitySession);
        await _dbContext.SaveChangesAsync();
        return createdActivitySession.Entity;
    }

    public async Task<Game> GetGameById(Guid gameId)
    {
        return (await _dbContext.Games.FirstOrDefaultAsync(x => x.Id == gameId))!;
    }

    public async Task<Game> UpdateGame(Game game)
    {
        var updatedGame = _dbContext.Update(game);
        await _dbContext.SaveChangesAsync();
        return updatedGame.Entity;
    }

    public async Task<ActivitySession> UpdateActivitySession(ActivitySession session)
    {
        var updatedGame = _dbContext.Update(session);
        await _dbContext.SaveChangesAsync();
        return updatedGame.Entity;
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