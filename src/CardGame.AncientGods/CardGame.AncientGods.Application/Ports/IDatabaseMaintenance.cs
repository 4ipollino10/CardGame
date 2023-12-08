namespace CardGame.AncientGods.Application.Ports;

public interface IDatabaseMaintenance
{
    IDatabaseMaintenance AsNoTrackingWithIdentityResolution();

    Task BeginTransaction();

    Task CommitTransaction();

    Task RollbackTransaction();
}