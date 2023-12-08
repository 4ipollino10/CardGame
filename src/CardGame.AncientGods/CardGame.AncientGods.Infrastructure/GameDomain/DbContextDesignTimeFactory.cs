using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CardGame.AncientGods.Infrastructure.GameDomain;

/// <summary>
/// Фабрика для миграций
/// </summary>
[UsedImplicitly]
public sealed class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<GameDbContext>
{
    private const string DefaultConnectionString = "Server=localhost;Port=5432;Database=game;User Id=postgres;Password=1";
    public static DbContextOptions<GameDbContext> GetSqlServerOptions(string? connectionString)
    {
        return new DbContextOptionsBuilder<GameDbContext>()
            .UseNpgsql(connectionString ?? DefaultConnectionString, x =>
            {
                x.MigrationsHistoryTable("__EFMigrationsHistory");
            })
            .Options;
    }
    public GameDbContext CreateDbContext(string[] args)
    {
        return new GameDbContext(GetSqlServerOptions(null));
    }
}