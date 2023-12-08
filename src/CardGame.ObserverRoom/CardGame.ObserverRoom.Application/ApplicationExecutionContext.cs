using CardGame.ObserverRoom.Application.Ports;

namespace CardGame.ObserverRoom.Application;

public class ApplicationExecutionContext
{
    private readonly IDatabaseMaintenance _databaseMaintenance;

    public ApplicationExecutionContext(IDatabaseMaintenance databaseMaintenance)
    {
        _databaseMaintenance = databaseMaintenance;
    }
    
    public Task<TResult> RunQuery<TResult>(Func<Task<TResult>> func)
    {
        _databaseMaintenance.AsNoTrackingWithIdentityResolution();

        return func();
    }

    public async Task RunCommand(Func<Task> func)
    {
        await _databaseMaintenance.BeginTransaction();

        try
        {
            await func();

            await _databaseMaintenance.CommitTransaction();
        }
        catch
        {
            await _databaseMaintenance.RollbackTransaction();
            throw;
        }
    }
}