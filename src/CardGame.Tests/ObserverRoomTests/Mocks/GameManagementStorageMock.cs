using CardGame.ObserverRoom.Application.Ports;
using CardGame.ObserverRoom.Core.GameDomain.Entities;
using CardGame.ObserverRoom.Core.Ports;

namespace CardGame.Tests.ObserverRoomTests.Mocks;

public class GameManagementStorageMock : IGamesManagementStorage, IDatabaseMaintenance
{
    public List<ActivitySession> ActivitySessions { get; set; } = new();

    public Task<ActivitySession?> GetActivitySessionById(Guid activitySessionId)
    {
        return Task.FromResult(ActivitySessions.Find(x => x.Id == activitySessionId));
    }

    public Task<List<ActivitySession>> GetAllActivitySessions()
    {
        return Task.FromResult(ActivitySessions);
    }

    public Task<List<Game>?> GetGamesByActivitySessionId(Guid activitySessionId)
    {
        return Task.FromResult<List<Game>?>(ActivitySessions.Find(x => x.Id == activitySessionId)!.Games);
    }

    public Task<ActivitySession> AddNewActivitySession(ActivitySession activitySession)
    {
        ActivitySessions.Add(activitySession);
        return Task.FromResult(activitySession);
    }

    public Task<Game> GetGameById(Guid gameId)
    {
        throw new NotImplementedException();
    }

    public Task<Game> UpdateGame(Game game)
    {
        throw new NotImplementedException();
    }

    public Task<ActivitySession> UpdateActivitySession(ActivitySession session)
    {
        throw new NotImplementedException();
    }

    public IDatabaseMaintenance AsNoTrackingWithIdentityResolution()
    {
        return this;
    }

    public Task BeginTransaction()
    {
        return Task.CompletedTask;
    }

    public Task CommitTransaction()
    {
        return Task.CompletedTask;
    }

    public Task RollbackTransaction()
    {
        return Task.CompletedTask;
    }
}